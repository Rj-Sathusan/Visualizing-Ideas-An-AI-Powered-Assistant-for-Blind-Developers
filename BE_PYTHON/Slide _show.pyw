import os
import subprocess
import time
import pyttsx3
import win32com.client
import keyboard
import winsound

# Function to get all PowerPoint file names from the "PP" folder
def get_powerpoint_files():
    folder_path = "PP"
    powerpoint_files = []
    for file_name in sorted(os.listdir(folder_path)):
        if file_name.endswith(".pptx") or file_name.endswith(".ppt"):
            powerpoint_files.append(file_name)
    return powerpoint_files

# Function to present the PowerPoint files and handle user input
def present_powerpoint_files(powerpoint_files):
    for file_name in powerpoint_files:
        print(f"PowerPoint File: {file_name}")
        #ask_decision("Do you want to open this PowerPoint file as a slide show?")
        ask_decision("Select File from given list")
        ask_decision(f"PowerPoint File , {file_name}")
        user_decision = get_user_decision()
        if user_decision == "right":
            ask_decision("slide show start")
            start_slide_show(file_name)
        else:
            ask_decision("Skipped")
            print("Skipped.")

# Function to ask the user's decision as a voice
def ask_decision(question):
    engine = pyttsx3.init()
    voices = engine.getProperty("voices")
    engine.setProperty("rate", 150)  # Adjust the rate of speech as needed
    engine.setProperty("voice", voices[1].id)  # Use the first available voice
    engine.say(question)
    engine.runAndWait()

# Function to get user's decision based on arrow key presses
def get_user_decision():
    while True:
        try:
            if keyboard.is_pressed("left"):
                return "left"
            elif keyboard.is_pressed("right"):
                return "right"
        except:
            pass

# Function to start a PowerPoint file as a slide show
def start_slide_show(file_name):
    file_path = os.path.join("PP", file_name)
    try:
        subprocess.run(["start", "/b", "powerpnt", "/s", file_path], shell=True)
        print(f"Started slide show for PowerPoint file: {file_name}")
        time.sleep(5)  # Wait for 15 seconds after starting the slide show
        move_and_speak_slide_headings()
    except Exception as e:
        print(f"Error starting slide show for PowerPoint file: {file_name}")
        print(e)

# Function to move through the slides and speak the headings
def move_and_speak_slide_headings():
    # Connect to PowerPoint application
    powerpoint_app = win32com.client.Dispatch("PowerPoint.Application")
    presentation = powerpoint_app.ActivePresentation
    slides_count = presentation.Slides.Count

    # Set the view to "Slide Show"
    slide_show_window = presentation.SlideShowSettings.Run()
    slide_show_view = slide_show_window.View

    # Initialize text-to-speech engine
    engine = pyttsx3.init()
    voices = engine.getProperty("voices")
    engine.setProperty("rate", 150)  # Adjust the rate of speech as needed
    engine.setProperty("voice", voices[1].id)  # Use the first available voice

    # Loop through the slides
    for slide_index in range(1, slides_count + 1):
        slide_show_view.GotoSlide(slide_index)

        # Get the heading text of the current slide
        slide = presentation.Slides(slide_index)
        heading_text = slide.Shapes.Title.TextFrame.TextRange.Text
        print(f"Slide {slide_index} - Heading: {heading_text}")

        # Speak the heading as a voice
        engine.say(heading_text)
        engine.runAndWait()
        # Move to the next slide after 2 minutes (120 seconds)
        time.sleep(5)
        winsound.Beep(1600, 200)  # The first argument is the frequency, and the second argument is the duration in milliseconds
        time.sleep(3)


        # Check for user input to skip the slide show
        if keyboard.is_pressed("left"):
            print("Slide show skipped.")
            break

    # Close PowerPoint application
    powerpoint_app.Quit()

# Main function
def main():
    powerpoint_files = get_powerpoint_files()
    present_powerpoint_files(powerpoint_files)

if __name__ == "__main__":
    main()
