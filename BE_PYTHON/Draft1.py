import keyboard
import speech_recognition as sr

recognizer = sr.Recognizer()
microphone = sr.Microphone()
is_listening = False

def start_voice_recognition():
    global is_listening
    is_listening = True
    print("Listening...")

    with microphone as source:
        audio = recognizer.listen(source)

    try:
        recognized_text = recognizer.recognize_google(audio)
        if recognized_text:
            print("Recognized text:", recognized_text)
        else:
            print("No speech input detected")
    except sr.UnknownValueError:
        print("Unable to recognize speech")
    except sr.RequestError as e:
        print("Error occurred: {0}".format(e))
    
    if is_listening:
        start_voice_recognition()

def stop_voice_recognition():
    global is_listening
    is_listening = False
    print("Voice recognition stopped")

def on_key_press(event):
    if event.name == 'ctrl':
        if is_listening:
            stop_voice_recognition()
        else:
            start_voice_recognition()

keyboard.on_press(on_key_press)

while True:
    pass
