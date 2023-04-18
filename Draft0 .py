from selenium import webdriver
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from element_manager import *
import re
import time
import os
import subprocess


# Define the command to start Chrome with remote debugging
chrome_cmd = 'C:\Program Files\Google\Chrome\Application\chrome.exe'
chrome_args = '-remote-debugging-port=9235 -user-data-dir=C:/Users/Rj_Sathusan/Desktop/Final Project/Visualizing-Ideas-An-AI-Powered-Assistant-for-Blind-Developers/chromeprofile --window-size=50,50'
chrome_full_cmd = f'"{chrome_cmd}" {chrome_args}'

# Start Chrome with remote debugging using subprocess
chrome_proc = subprocess.Popen(chrome_full_cmd)



# Set the path to the chromedriver.exe file
chrome_driver_path = r'C:\Users\Rj_Sathusan\Desktop\Final Project\Visualizing-Ideas-An-AI-Powered-Assistant-for-Blind-Developers\chromedriver.exe'

# Set the debugger address option
chrome_options = webdriver.ChromeOptions()
chrome_options.add_experimental_option("debuggerAddress", "localhost:9235")

# Create a new instance of the Chrome driver with the options
driver = webdriver.Chrome(executable_path=chrome_driver_path, options=chrome_options)

# Open Facebook.com in the Chrome browser
driver.get("https://chat.lmsys.org/")

# Get the initial HTML source code of the page
html_source = driver.page_source

# Find all the <p> tags in the initial HTML source code
start = '<p>'
end = '</p>'
pattern = re.escape(start) + '(.*?)' + re.escape(end)
all_p_tags = re.findall(pattern, html_source)

while True:
    question = str(input("Me: "))

    # to click on input field
    driver.find_element(By.XPATH,get_xpath(driver,'REKWbCALTXYxkuZ')).click()

    # to type content in input field
    driver.find_element(By.XPATH,get_xpath(driver,'17mjrmQX6KVar3C')).send_keys(question)

    # to click on the element(Send) found
    driver.find_element(By.XPATH,get_xpath(driver,'ODMFCLCdwxYWQ7L')).click()


    # Find the input field and type the question
    #driver.find_element(By.XPATH, get_xpath(driver, 'IpkfL_zBPpYSfcu')).send_keys(question)

    # Click the button to submit the question
    #driver.find_element(By.XPATH, get_xpath(driver, 'cRU_NKDxzRpnIBX')).click()

    # Wait for the new <p> tags to load
    time.sleep(10)

    # Get the new HTML source code of the page
    new_html_source = driver.page_source

    # Find all the <p> tags in the new HTML source code
    new_p_tags = re.findall(pattern, new_html_source)

    # Print the newly added <p> tags
    for i in range(len(all_p_tags), len(new_p_tags)):
        extracted_text = re.sub('<.*?>', '', new_p_tags[i-1])
        print(extracted_text)

    # Update the list of all <p> tags
    all_p_tags = new_p_tags
