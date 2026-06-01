import requests

def safe_get(url):
    response = requests.get(url)
    status_code = response.status_code

    if status_code == 200:
        return response.json()
    elif status_code == 404:
        return None
    else:
        raise Exception(f"The request failed with status code: {status_code}")

