from mega import Mega
from tqdm import tqdm
import time
import os

# Authenticate with Mega using your email and password
mega_email = 'micawih451@minterp.com'
mega_password = '@@furies4'
mega = Mega()
m = mega.login(mega_email, mega_password)

def download_file(m, node_name, retry_count=3):
    for _ in range(retry_count):
        try:
            find = m.find(node_name)
            if find:
                destination_dir = os.path.join(os.path.dirname(__file__), 'BackUp')  # Use a relative path
                file = m.download(find, destination_dir)  # Save the file to the 'BackUp' directory
                print(f'Downloaded file: {node_name}')
                return
        except Exception as e:
            print(f'Error downloading file: {node_name}')
            print(f'Error details: {str(e)}')
            print('Retrying download...')
            time.sleep(5)  # Wait for a few seconds before retrying
    print(f'Failed to download file: {node_name}')

def list_and_download_files_in_folder(folder_name):
    # Find the folder in your Mega account
    folder_info = m.find(folder_name)

    # Check if the folder was found
    if not folder_info:
        print(f"Folder '{folder_name}' not found in your Mega account.")
        return

    # Get the node ID of the folder
    folder_node_id = folder_info[0]

    # Get all files and folders within the specified folder
    files_and_folders = m.get_files_in_node(folder_node_id)

    # List the files in the folder
    print(f"Files in '{folder_name}':")

    # Create a progress bar
    for node_id, node_info in tqdm(files_and_folders.items(), unit='file'):
        node_name = node_info['a']['n']
        node_id = node_info['h']

        # Check if it's a file (not a folder)
        if node_info['t'] == 0:
            print(f'Name: {node_name}, Node ID: {node_id}')

            # Download the file with retries
            download_file(m, node_name)

# Call the function and provide the folder name you want to list and download
folder_name_to_list = 'New Subfolder'
list_and_download_files_in_folder(folder_name_to_list)
