from selenium import webdriver
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from element_manager import *
import re

driver = webdriver.Chrome(ChromeDriverManager().install())
import time
# to open the url in browser 2
driver.get('https://chatgpt123.online/')

# to click on input field
driver.find_element(By.XPATH,get_xpath(driver,'_AvovM2JAHM9Vuc')).click()

# to click on input field
driver.find_element(By.XPATH,get_xpath(driver,'EF2Zz7Qh7G1CrkX')).click()

# to type content in input field
driver.find_element(By.XPATH,get_xpath(driver,'p4NU9Wg_MapoKPk')).send_keys('what is network')

# to click on the element found
driver.find_element(By.XPATH,get_xpath(driver,'xjDeYWkN4Tclk7L')).click()

time.sleep(20)

# Get the full HTML source code of the page
html_source = driver.page_source

# Print the HTML source code
#print(html_source)

start = 'overflow-hidden"><p>'
end = '</p></p>'

pattern = re.escape(start) + '(.*?)' + re.escape(end)
# re.escape() is used to escape special characters in the start and end strings
# (.*?) is used to match any character (non-greedy) between the start and end strings

result = re.search(pattern, html_source)

if result:
    extracted_text = re.sub('<.*?>', '', result.group(1))  # remove HTML tags using regex substitution
    print(extracted_text)
else:
    print('No match found.')
    
# Close the webdriver
driver.quit()

