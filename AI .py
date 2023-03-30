import speech_recognition as sr
import pyttsx3
import time
import pyaudio
import datetime
import winsound


# Initialize recognizer instance
r = sr.Recognizer()

engine = pyttsx3.init('sapi5')
voices = engine.getProperty('voices')
engine.setProperty('rate', 135)  # adjust the rate to 150 words per minute
engine.setProperty('voice',voices[1].id) #index '0' for 'David'(male) voice index '1' for 'zira'(female) voice

#Main classs where all the functiona are present
class MainThread():
    def __init__(self):
        super(MainThread,self).__init__()
    
    def run(self):
        self.Intro()
    
    #function that will take the commands  to convert voice into text
    def take_Command(self):
        try:
            listener = sr.Recognizer()
            with sr.Microphone() as source:
                #self.talk('Hello sir I am Luna !, your assistant. please tell me how can i help you')

                winsound.Beep(1600, 100) # The first argument is the frequency, and the second argument is the duration in milliseconds
                listener.pause_threshold = 1
                voice = listener.listen(source,timeout=10,phrase_time_limit=7)
                print("Recognizing...")
                command1 = listener.recognize_google(voice,language='en-in')
                command1 = command1.lower()  
                if 'Luna' in command1: 
                    command1 = command1.replace('Luna','')
                
            return command1
        except:
            return 'None'
        
    #Luna commands controller 
    def run_Luna(self):
        self.wish()
        self.talk('Hello boss I am Luna your assistant. please tell me how can i help you')
        while True:
            self.command = self.take_Command() #Every time taking command after a task is done
            print(self.command)
            
    
    #Intro msg
    def Intro(self):
        while True:
            self.permission = self.take_Command()
            print(self.permission)
            if ("wake up" in self.permission) or ("get up" in self.permission):
                self.run_Luna()
            elif ("goodbye" in self.permission) or ("get lost" in self.permission):
                self.talk("Thanks for using me boss, have a good day")
                sys.exit()
                
    #Talk 
    def talk(self,text):
        engine.say(text)
        engine.runAndWait()

    def Cal_day(self):
        day = datetime.datetime.today().weekday() + 1
        Day_dict = {1: 'Monday', 2: 'Tuesday', 3: 'Wednesday',4: 'Thursday', 5: 'Friday', 6: 'Saturday',7: 'Sunday'}
        if day in Day_dict.keys():
            day_of_the_week = Day_dict[day]
            print(day_of_the_week)
    #Wish
    def wish(self):
        hour = int(datetime.datetime.now().hour)
        t = time.strftime("%I:%M %p")
        day = self.Cal_day()
        print(t)
        if (hour>=0) and (hour <=12) and ('AM' in t):
            self.talk(f'Good morning boss, its {day} and the time is {t}')
        elif (hour >= 12) and (hour <= 16) and ('PM' in t):
            self.talk(f"good afternoon boss, its {day} and the time is {t}")
        else:
            self.talk(f"good evening boss, its {day} and the time is {t}")
            

if __name__ == "__main__":
    Luna = MainThread()
    Luna.run()