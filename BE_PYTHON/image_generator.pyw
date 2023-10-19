import os
import requests
import json
from PIL import Image
from io import BytesIO
import tkinter as tk
from tkinter import ttk

def download_images(query):
    url = "https://api.pexels.com/v1/search"
    api_key = "1wD5u7uB7AsuMyY1AaJpNLcu0JG7Zzh90eQBwNAIMpVsWNL1NNrHQxg0"
    num_images = 6
    store_dir = os.path.join("STORE", query)

    if not os.path.exists(store_dir):
        os.makedirs(store_dir)

    for i in range(1, num_images + 1):
        params = {
            "query": query,
            "per_page": 1,
            "page": i,
            "size": "original",
        }
        headers = {
            "Authorization": api_key,
        }

        try:
            response = requests.get(url, headers=headers, params=params, stream=True)
            response.raise_for_status()
            data = json.loads(response.text)

            if data["total_results"] > 0:
                image_url = data["photos"][0]["src"]["large"]
                image_response = requests.get(image_url, stream=True)
                image_data = BytesIO()

                total_length = int(image_response.headers.get('content-length'))

                with open(os.path.join(store_dir, f"{query}{i}.png"), "wb") as image_file:
                    for data in image_response.iter_content(chunk_size=1024):
                        image_data.write(data)
                        image_file.write(data)

                print(f"Downloaded: {query}{i}.png")
            else:
                print(f"No images found for '{query}'")
                break
        except requests.exceptions.RequestException as e:
            print(f"API request failed: {e}")
            break

# Launch the download with a progress bar
#download_images_with_progress('Men')

