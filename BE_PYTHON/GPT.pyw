import openai
import presentaion_generator
import re


openai.api_key = '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'


def get_api_response(prompt: str) -> str | None:
    """
    Get a response from the OpenAI API based on the given prompt.
    """
    text: str | None = None

    try:
        response: dict = openai.Completion.create(
            model='text-davinci-003',
            prompt=prompt,
            temperature=0.9,
            max_tokens=150,
            top_p=1,
            frequency_penalty=0,
             presence_penalty=0.6,
            stop=[' Human:', ' AI:']
        )

        choices: dict = response.get('choices')[0]
        text = choices.get('text')

    except Exception as e:
        print('ERROR:', e)
 
    return text


def update_list(message: str, pl: list[str]):
    """
    Update the prompt list with a new message.
    """
    pl.append(message)


def create_prompt(message: str, pl: list[str]) -> str:
    """
    Create a complete prompt by adding the user's message to the prompt list.
    """
    p_message: str = f'\nHuman: {message}'
    update_list(p_message, pl)
    prompt: str = ''.join(pl)
    return prompt


def get_bot_response(message: str, pl: list[str]) -> str:
    """
    Get a response from the AI based on the user's message and prompt list.
    """
    prompt: str = create_prompt(message, pl)
    bot_response: str = get_api_response(prompt)

    if bot_response:
        update_list(bot_response, pl)
        pos: int = bot_response.find('\nAI: ')
        bot_response = bot_response[pos + 5:]
    else:
        bot_response = 'Something went wrong...'

    return bot_response


def generate_content():
    """
    Generate content, including titles and notes, based on descriptions.
    """
    prompt_list: list[str] = ['You are Ai assistant Luuna for helping blind developers ',
                              '''
Generate four set titles and notes for given paragraph in the format 'Titles : [title1, title2, title3, title4], Notes : [note1, note2, note3, note4]' for a topic related. 
Ensure that each title and note combination is concise, with titles ranging from 2 to 3 words, and notes difinitly need 40 to 45 words.
                              '''
                            ]

    user_input: str = input('You: ')
    
   
    head=generate_heading(user_input)
    print(head)
    input('You: ')
     
    cleaned_input = re.sub(r'[^A-Za-z\s]', '', user_input)
    response: str = get_bot_response(cleaned_input, prompt_list)
    new_text = 'Titles' + response[response.find(' '):]
    # Replace ':' with '='
    data = new_text.replace('=', ':')
    print(data)
    
    presentaion_generator.genrater(data,head)
    response=response+"']"
    #print(f'Bot: {response}')



def answer_questions():
    """
    Answer direct questions from users.
    """
    prompt_list: list[str] = ['You are Ai assistant Luuna for helping blind developers ',
                              'Give direct answers to given questions'
                            ]

    while True:
        user_input: str = input('You: ')
        response: str = get_bot_response(user_input, prompt_list)
        print(f'Bot: {response}')

def rewirte():
    """
    Answer direct questions from users.
    """
    prompt_list: list[str] = ['You are Ai assistant Luuna for helping blind developers ',
                              'Give direct answers to given questions'
                            ]

    while True:
        response: str = get_bot_response(user_input, prompt_list)
        
def generate_heading(user_input):
    """
    Generate suitable short titles based on descriptions.
    """
    prompt_list: list[str] = ['You are Ai assistant Luuna for helping blind developers ',
                              'Give suitable short within 3 words titles for a given description directly give the title without any other single string '
                            ]

    while True:
        response: str = get_bot_response(user_input, prompt_list)
        #print(f'Bot: {response}')
        colon_index = response.find(':')
        if colon_index != -1:
        # Remove all text before and including the colon symbol
            cleaned_text = response[colon_index + 1:]
        print(cleaned_text)
        return cleaned_text
        


generate_content()
