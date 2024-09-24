from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from transformers import pipeline
from datetime import datetime
from jsonschema import validate, ValidationError
from datetime import datetime

# JSON Schema for ChatData
schema = {
    "type": "object",
    "properties": {
        "Message": {"type": "string"},
        "SenderEmail": {"type": "string"},
        "ReceiverEmail": {"type": "string"},
        "Timestamp": {"type": "string", "format": "date-time"},
    },
    "required": ["Message", "Timestamp", "SenderEmail", "ReceiverEmail"],
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
    timestamp = db.Column(db.String(255),  name='Timestamp')

@app.route('/analyze', methods=['POST'])
def analyze_message():
    data = request.json

    print("Received data:", data)  # Debugging line to see received data


    try:
        validate(instance=data, schema=schema)
    except ValidationError as e:
        return jsonify({"error schema": str(e)}), 400

    message = data.get('Message')
    sender_email = data.get('SenderEmail') 

    if not message or not sender_email:
        return jsonify({"error": "No message or sender email provided"}), 400

    gpt2_response = generator(message, max_length=20, num_return_sequences=1, truncation=True)[0]['generated_text']

    gpt2_response = gpt2_response.replace('\n', ' ').replace('\r', '')  # Remove newline characters
    gpt2_response = gpt2_response.replace('"', '').replace("'", '')     # Remove quotes (single and double)
    gpt2_response = gpt2_response.replace('(', '').replace(')', '')     # Remove parentheses

    # Create ChatData instance
    chat_entry = ChatData(
        sender_email=sender_email,
        receiver_email='chatbot',
        message=message,
        timestamp = datetime.utcnow().isoformat(timespec='seconds')
    )

    bot_chat_entry = ChatData(
        sender_email='chatbot',
        receiver_email=sender_email,
        message=gpt2_response,
        timestamp=datetime.utcnow().isoformat() + 'Z'
    )

    # Save the chat entry to the database
    db.session.add(chat_entry)
    db.session.add(bot_chat_entry)
    db.session.commit()

    return jsonify({"response": gpt2_response})

# Run Flask server
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5015)
