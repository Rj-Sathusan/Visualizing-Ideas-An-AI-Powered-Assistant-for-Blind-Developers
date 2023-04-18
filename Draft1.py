import os
import subprocess
from selenium import webdriver
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from element_manager import *

# Define the command to start Chrome with remote debugging
chrome_cmd = 'C:\Program Files\Google\Chrome\Application\chrome.exe'
chrome_args = '-remote-debugging-port=9235 -user-data-dir=C:/Users/Rj_Sathusan/Desktop/Final Project/Visualizing-Ideas-An-AI-Powered-Assistant-for-Blind-Developers/chromeprofile --window-size=50,50'
chrome_full_cmd = f'"{chrome_cmd}" {chrome_args}'

# Start Chrome with remote debugging using subprocess
chrome_proc = subprocess.Popen(chrome_full_cmd)
