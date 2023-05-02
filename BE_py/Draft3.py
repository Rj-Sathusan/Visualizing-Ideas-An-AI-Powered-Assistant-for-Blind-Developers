from transformers import pipeline, set_seed

# Load the model
model_name = "EleutherAI/vicuna-mlm-13B"
model = pipeline('text-generation', model=model_name, tokenizer=model_name, device=0)

# Set the seed for reproducibility
set_seed(42)

# Generate text using the model
prompt = "The quick brown fox jumps over the"
generated_text = model(prompt, max_length=50, num_return_sequences=1)

# Print the generated text
print(generated_text[0]['generated_text'])
