import requests
import json


# set the API endpoint and access key
url = "https://api.pexels.com/v1/search"
api_key = "1wD5u7uB7AsuMyY1AaJpNLcu0JG7Zzh90eQBwNAIMpVsWNL1NNrHQxg0"

# set the search query and parameters
query = "AI Problms"
params = {
    "query": query,
    "per_page": 1,
    "size": "large",
}

# set the authorization header with the API access key
headers = {
    "Authorization": api_key,
}

# send the API request
response = requests.get(url, headers=headers, params=params)

# parse the response JSON data
data = json.loads(response.text)

# get the URL of the first image returned
if data["total_results"] > 0:
    image_url = data["photos"][0]["src"]["large"]
    print(f"URL of the first image for '{query}': {image_url}")
else:
    print(f"No images found for '{query}'")
