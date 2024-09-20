from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from transformers import pipeline
from sqlalchemy import text
from datetime import datetime

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:postgres1@localhost:5013/MessageDoctor'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
db = SQLAlchemy(app)
generator = pipeline("text-generation", model="openai-community/gpt2")

class ChatData(db.Model):
    __tablename__ = 'chat_data'
    id = db.Column(db.Integer, primary_key=True)
    sender_email = db.Column(db.String, nullable=False)
    receiver_email = db.Column(db.String, nullable=False)
    message = db.Column(db.String, nullable=False)
    timestamp = db.Column(db.DateTime, default=datetime.utcnow)  # Add timestamp field

@app.route('/analyze', methods=['POST'])
def analyze_message():
    data = request.json
    message = data.get('message')
    sender_email = data.get('senderEmail')  # Receive sender email

    if not message or not sender_email:
        return jsonify({"error": "No message or sender email provided"}), 400

    # Generate response using GPT-2
    gpt2_response = generator(message, max_length=250, num_return_sequences=1)[0]['generated_text']

    # Create ChatData instance
    chat_entry = ChatData(
        sender_email=sender_email,
        receiver_email='chatbot', 
        message=message,
        response=gpt2_response
    )

    # Save the chat entry to the database
    db.session.add(chat_entry)
    db.session.commit()

    return jsonify({"response": gpt2_response})

# Run Flask server
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5015)
