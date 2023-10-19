from mega import Mega
import os
from tqdm import tqdm  # Import tqdm for the progress bar

# Specify the Mega folder name and Mega credentials
mega_folder_name = 'try'
mega_email = 'micawih451@minterp.com'
mega_password = '@@furies4'


# Authenticate with Mega using provided credentials
mega = Mega()
m = mega.login(mega_email, mega_password)

        
def Create_folder(mega_folder_name):
    # Check if the folder exists, and if not, create it
    mega_folder = m.find(mega_folder_name)
    if not mega_folder:
        mega_folder = m.create_folder(mega_folder_name)
        print(f"Created Mega folder: {mega_folder_name}")
    
    # Get the public link for the created folder
    folder_link = m.get_upload_link(mega_folder[0])  # Use [0] to get the first item (folder) in the list
    
    # Print the public link
    print("Public link for the created folder:", folder_link)

def mega_upload_folder(mega_folder_name):
    try:
        # Get the current working directory
        current_dir = os.getcwd()

        # Combine the current directory with the folder path
        folder_path = os.path.join(current_dir, 'STORE', 'India')
        mega_folder = m.find(mega_folder_name)

        # Get a list of files in the specified folder
        files = [f for f in os.listdir(folder_path) if os.path.isfile(os.path.join(folder_path, f))]

        # Upload each file to the Mega folder with a progress bar
        for file_name in tqdm(files, desc="Uploading files"):
            file_path = os.path.join(folder_path, file_name)
            m.upload(file_path, mega_folder[0])

        print("Upload completed.")
    except Exception as e:
        print(f"An error occurred: {str(e)}")

# Create the Mega folder if it doesn't exist
#Create_folder(mega_folder_name)

# Call the function to upload the folder
mega_upload_folder(mega_folder_name)
