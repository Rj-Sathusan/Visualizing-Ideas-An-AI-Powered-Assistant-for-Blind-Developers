import requests

url = "https://docsgpt.arc53.com/"

data = {
    "question": "What is the capital of France?",
    "api_key": "token",
    "embeddings_key": "token",
    "history": None,
    "active_docs": "python/.project/3.11.1/huggingface_sentence-transformers-all-mpnet-base-v2/",
    "model": "default"
}

response = requests.post(url, json=data)

print(response.text)
