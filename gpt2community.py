from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from transformers import pipeline
from datetime import datetime
from jsonschema import validate, ValidationError

# JSON Schema for ChatData
schema = {
    "type": "object",
    "properties": {
        "message_id": {"type": "integer"},
        "message": {"type": "string"},
        "timestamp": {"type": "string","format": "date-time"},
        "sender_email": {"type": "string"},
        "receiver_email": {"type": "string"},
    },
    "required": ["message", "timestamp", "sender_email", "receiver_email"],
}

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:postgres1@localhost:5013/MessageDoctor'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
db = SQLAlchemy(app)

# Initialize the text generation pipeline with GPT-2
generator = pipeline("text-generation", model="openai-community/gpt2")

class ChatData(db.Model):
    __tablename__ = 'chat_data'
    message_id = db.Column(db.Integer, primary_key=True, autoincrement=True, name='MessageId')
    sender_email = db.Column(db.String(255), nullable=False, name='SenderEmail')
    receiver_email = db.Column(db.String(255), nullable=False, name='ReceiverEmail')
    message = db.Column(db.Text, nullable=False, name='Message')
    timestamp = db.Column(db.DateTime, default=datetime.utcnow, name='Timestamp')

@app.route('/analyze', methods=['POST'])
def analyze_message():
    data = request.json
    try:
        validate(instance=data, schema=schema)
    except ValidationError as e:
        return jsonify({"error schema": str(e)}), 400

    message = data.get('message')
    sender_email = data.get('sender_email')  # Corrected key to match schema

    if not message or not sender_email:
        return jsonify({"error": "No message or sender email provided"}), 400

    # Generate response using GPT-2
    gpt2_response = generator(message, max_length=150, num_return_sequences=1)[0]['generated_text']

    # Create ChatData instance
    chat_entry = ChatData(
        sender_email=sender_email,
        receiver_email='chatbot',
        message=message,
        timestamp=datetime.utcnow()  # Explicitly set timestamp if needed
    )

    bot_chat_entry = ChatData(
        sender_email='chatbot',
        receiver_email=sender_email,
        message=gpt2_response,
        timestamp=datetime.utcnow()
    )

    # Save the chat entry to the database
    db.session.add(chat_entry)
    db.session.add(bot_chat_entry)
    db.session.commit()

    return jsonify({"response": gpt2_response})

# Run Flask server
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5015)
