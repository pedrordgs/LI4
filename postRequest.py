import requests
from os import listdir
from os.path import isfile, join

path="/mnt/c/Users/Portatil/Desktop/LI4/Distritos/"
files = [f for f in listdir(path) if isfile(join(path, f))]
headers = {'Accept' : 'application/json', 'Content-Type' : 'application/json'}

for f in files:
    print("POST: " + f)
    contents = open(path+f, 'rb').read()
    # print(contents)
    r = requests.post("https://portourgalapi.azurewebsites.net/api/distritos/", data=contents, headers=headers)
    print(r.status_code);
