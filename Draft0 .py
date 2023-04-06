import re

text = '''<!-- Partie Fatoumata -->
  <div class="main position-absolute min-vh-100 end-0 d-flex flex-column justify-content-between align-items-center">
    <div class="container_main mt- text-center d-flex flex-column justify-content-center align-items-center"></div>


  <!-- Partie Yasmine -->
  <div class="question_response_container my-2">
    <div id="response" class="content-box">
<div class="user_question rounded text-white d-flex justify-content-between align-items-center p-4">   
  <div class="typewriter d-flex align-items-center m-3">           
    <img src="./icon.png" alt="icon" class="me-3 rounded">
    <p>what is software</p>
  </div>
  <div class="icon_container">
    <i class="bi bi-pencil-square me-2 fs-5"></i>
  </div>              
</div>
<div class="rounded text-white d-flex justify-content-between align-items-center p-4">  
  <div class="   m-3">
    <img src="./logo.png" alt="logo" class=" m-3 rounded">
    <p id="56D8tbi2BRbAtQ77" class="response_paragraph position-relative overflow-hidden"><p>Software refers to a set of instructions or programs that are designed to perform specific tasks on a computer or other electronic device. It includes applications, operating systems, utilities, and other programs that enable users to perform various functions, such as word processing, browsing the internet, playing games, and managing data. Software can be installed on a computer or device, or it can be accessed through the internet or a network.</p></p>
  </div>


</div>
</div>
    <div class="   col-12 chat-box">'''

start = 'overflow-hidden"><p>'
end = '</p></p>'

pattern = re.escape(start) + '(.*?)' + re.escape(end)
# re.escape() is used to escape special characters in the start and end strings
# (.*?) is used to match any character (non-greedy) between the start and end strings

result = re.search(pattern, text)

if result:
    extracted_text = re.sub('<.*?>', '', result.group(1))  # remove HTML tags using regex substitution
    print(extracted_text)
else:
    print('No match found.')
