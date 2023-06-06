import requests
import pyttsx3
import time
import keyboard

# Initialize text-to-speech engine
engine = pyttsx3.init()

# Keep track of previous message count
previous_count = 0

# Function to extract the login username and domain from the email address
def extract(email):
    username, domain = email.split("@")
    return username, domain

# Function to fetch and display all emails
def display_emails():
    global previous_count  # Declare previous_count as a global variable
    email = "Vecna@1secmail.com"  # Replace with your email address
    username, domain = extract(email)
    url = f"https://www.1secmail.com/api/v1/?action=getMessages&login={username}&domain={domain}"
    response = requests.get(url)
    
    if response.status_code == 200:
        emails = response.json()
        current_count = len(emails)
        
        if current_count > previous_count:
            print(f"You have {current_count} new email(s):")
            engine.say(f"You have {current_count} new email(s):")
            engine.say("Press the right arrow key to read new emails, or the left arrow key to skip.")
            print("Press the right arrow key to read new emails, or the left arrow key to skip.")
            engine.runAndWait()

            # Wait for the right or left arrow key press
            key = keyboard.read_key()
            
            if key == "right":
                for index, email in enumerate(emails, start=1):
                    email_id = email.get("id")
                    email_details_url = f"https://www.1secmail.com/api/v1/?action=readMessage&login={username}&domain={domain}&id={email_id}"
                    email_details_response = requests.get(email_details_url)
                    email_details = email_details_response.json()
                    print(f"\nEmail #{index}:")
                    print("Sender:", email_details.get("from"))
                    print("Subject:", email_details.get("subject"))
                    body = email_details.get("textBody")
                    
                    if body:
                        print("Body:", body)
                        # Read the email using text-to-speech
                        engine.say(f"You have received an email from {email_details['from']}.")
                        engine.say(f"The subject is {email_details['subject']}.")
                        engine.say("The body of the email is as follows:")
                        engine.say(body)
                        engine.runAndWait()
                    else:
                        print("No body found for this email.")

                # Ask to delete emails
                engine.say("Do you want to delete all emails?")
                print("Do you want to delete all emails?")
                engine.runAndWait()
                delete_key = keyboard.read_key()
                
                if delete_key == "right":
                    delete_emails()
                    say = "All emails have been deleted "
                elif delete_key == "left":
                    say = "eMails Not... Deleted "
                else:
                    say = ""
                
                engine.say(say)
                engine.runAndWait()

            elif key == "left":
                print("Skipping reading emails.")
            else:
                print("Invalid key press.")
        
        # Update the previous count
        previous_count = current_count
        
    else:
        print("Failed to fetch emails.")


# Function to delete all emails
def delete_emails():
    email = "Vecna@1secmail.com"  # Replace with your email address
    username, domain = extract(email)
    url = f"https://www.1secmail.com/mailbox"
    data = {
        'action': 'deleteMailbox',
        'login': username,
        'domain': domain
    }
    response = requests.post(url, data=data)
    
    if response.status_code == 200:
        print("All emails have been deleted.")
    else:
        print("Failed to delete emails.")


# Entry point
if __name__ == "__main__":
    while True:
        display_emails()
        time.sleep(5)  # Delay between each iteration (e.g., 5 seconds)
