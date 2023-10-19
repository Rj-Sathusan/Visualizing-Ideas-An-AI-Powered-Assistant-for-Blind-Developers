import speech_recognition as sr
import pyttsx3
import time
import pyaudio
import datetime
import keyboard
import winsound
import sys
import urllib

# Initialize recognizer instance
r = sr.Recognizer()

engine = pyttsx3.init('sapi5')
voices = engine.getProperty('voices')
engine.setProperty('rate', 135)  # adjust the rate to 150 words per minute
engine.setProperty('voice', voices[1].id)  # index '0' for 'David' (male) voice, index '1' for 'zira' (female) voice

internet_status = False

# Main class where all the functions are present
class MainThread():
    def __init__(self):
        super(MainThread, self).__init__()

    def run(self):
        self.Intro()

    # function that will take the commands to convert voice into text
    def take_Command(self):
        try:
            global internet_status  # Add global keyword to access the global variable

            try:
                urllib.request.urlopen('http://www.google.com', timeout=5)
                if internet_status == False:
                    print("Internet connection is active.")
                    self.talk("Internet connection is active.")
                internet_status = True

            except:
                if internet_status == True:
                    print("Internet connection is inactive.")
                    self.talk("Internet connection is inactive.")
                internet_status = False
                time.sleep(2)
                return None

            listener = sr.Recognizer()
            with sr.Microphone() as source:
                winsound.Beep(1600, 100)  # The first argument is the frequency, and the second argument is the duration in milliseconds
                listener.pause_threshold = 1
                voice = listener.listen(source, timeout=10, phrase_time_limit=15)
                print("Recognizing...")
                command1 = listener.recognize_google(voice, language='en-in')
                command1 = command1.lower()
                if 'Luna' in command1:
                    command1 = command1.replace('Luna', '')

                keyboard.write(" " + command1)

            return command1
        except:
            return None

    # Luna commands controller
    def run_Luna(self):
        while True:
            self.command = self.take_Command()  # Every time taking command after a task is done
            print(self.command)

    def Intro(self):
        self.wish()
        while True:
            self.permission = self.take_Command()
            print(self.permission)
            if self.permission is not None and ("goodbye" in self.permission or "get lost" in self.permission):
                self.talk("Thanks for using me boss, have a good day")
                sys.exit()

    # Function to get the appropriate wish based on time
    def get_wish(self):
        current_time = datetime.datetime.now()
        hour = current_time.hour
        if hour < 12:
            wish = "Good morning"
        elif 12 <= hour < 17:
            wish = "Good afternoon"
        else:
            wish = "Good evening"

        return wish

    # Function to get the current date, location, and day
    def get_datetime_location(self):
        current_time = datetime.datetime.now()
        date = current_time.strftime("%B %d ")
        location = "New York"  # Replace with your desired location
        day = current_time.strftime("%A")

        return date, location, day

    # Function to make Luna speak the wish with date, location, and day
    def wish(self):
        wish = self.get_wish()
        date, location, day = self.get_datetime_location()
        self.talk(f"Hello Dear, {wish} , I am Luna, your assistant. Today is {date} , It's {day}, Please tell me how can I help you")

    # Function to make Luna speak the provided text
    def talk(self, text):
        engine.say(text)
        engine.runAndWait()


if __name__ == "__main__":
    Luna = MainThread()
    Luna.run()
