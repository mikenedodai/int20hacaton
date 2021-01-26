#%%
import requests
from bs4 import BeautifulSoup
import time
import random
from tqdm import tqdm_notebook as tqdm
import gc
import json
import re
#%%
def parse_weight(weight):
    try:
        int_weight = int(re.sub("\D", "", weight))
        if int_weight == 1:
            int_weight = 1000
        if int_weight > 1000:
            w = (re.findall("\d+", weight))
            int_weight = int(w[0]) * int(w[1])
        return int_weight
    except:
        return "None"

def parse_price(price):
    try:
        price = price.replace('\n','')
        price = (re.findall("\d+", price))
        if len(price) == 2:
            final_price = float(f"{price[0]}.{price[1]}")
        else:
            final_price = float(f"{price[0]}.00")
        return (final_price)
    except Exception as e:
        return e

def find_price_at_strig(title):
    title_price = re.findall(r'\d+', title)
    if len(title_price) == 0:
        return "None"
    else:
        title_price = [int(i) for i in title_price]
        return max(title_price)
#%%
def auchan_parser():
    url = requests.get('https://auchan.zakaz.ua/uk/categories/buckwheat-auchan/')
    soup = BeautifulSoup(url.text, 'html.parser')

    price = soup.find_all('span', {'class' : 'jsx-3642073353 Price__value_caption'})
    price = [float(span.get_text()) for span in price]

    #images = soup.find_all('span', {'class' : 'jsx-725860710 product-tile__image-i'})
    #images = [span.get_text() for span in images]

    images = []
    for a in soup.find_all('a', {'class' : 'jsx-725860710 product-tile'}):
        if a.img:
            images.append(a.img['src'])

    item_url = soup.find_all(href=True)
    item_url = list(set(["https://auchan.zakaz.ua/"+i['href'] for i in item_url if i['href'][:11] == "/uk/products"]))

    product_title = soup.find_all('span', {'class' : 'jsx-725860710 product-tile__title'})
    product_title = [span.get_text() for span in product_title]

    product_weight = soup.find_all('div', {'class' : 'jsx-725860710 product-tile__weight'})
    product_weight = [span.get_text() for span in product_weight]
    product_weight = [parse_weight(w.split()[0]) for w in product_weight]

    if len(price) != len(product_title):
        diff = len(product_title) - len(price)
        for i in range(diff):
            price.append("None")

    per_kg_price = []

    for idx, p in enumerate(price):
        if p != "None" and product_weight[idx] != "None":
            per_kg_price.append(p / product_weight[idx] * 1000)
        else:
            per_kg_price.append("None")

    return price,per_kg_price, product_title, product_weight, images, item_url

auchan_parser()
# %%
def epicentric_parser():
    url = requests.get('https://epicentrk.ua/shop/krupy-i-makaronnye-izdeliya/fs/vid-krupa-grechnevaya/')
    soup = BeautifulSoup(url.text, 'html.parser')

    product_title = soup.find_all('b', {'class' : 'nc'})
    product_title = [span.get_text() for span in product_title]
    product_title = [span.replace("\n", "") for span in product_title]

    item_url = soup.find_all(href=True)
    item_url = list(set([i['href'] for i in item_url if i['href'][-4:] == "html"]))

    #re.sub('[^A-Za-z0-9]+', '', mystring)

    #images = soup.find_all('a', {'class' : 'card__photo'})
    #images = [span['img'] for span in images]
    images = []
    for a in soup.find_all('a', {'class' : 'card__photo'}):
        if a.img:
            images.append(a.img['src'])

    price = soup.find_all('span', {'class' : 'card__price-sum'})
    price = [parse_price(span.get_text()) for span in price]

    product_weight = soup.find_all('ul', {'class' : 'card__characteristics'})
    product_weight = [span.get_text() for span in product_weight]
    product_weight = [parse_weight(w.split()[-2]) for w in product_weight]

    if len(price) != len(product_title):
        diff = len(product_title) - len(price)
        for i in range(diff):
            price.append("None")

    per_kg_price = []
    for idx, p in enumerate(price):
        if p != "None" and product_weight[idx] != "None":
            per_kg_price.append(p / product_weight[idx] * 1000)
        else:
            per_kg_price.append("None")

    return price, per_kg_price, product_title, product_weight, images
epicentric_parser()
# %%
def fozzy_parser():
    url = requests.get('https://fozzyshop.ua/300143-krupa-grechnevaya')
    soup = BeautifulSoup(url.text, 'html.parser')

    product_title =  soup.find_all('div', {'class' : 'h3 product-title'})
    product_title = [span.get_text() for span in product_title] 
    product_title = [span.replace("\n", "") for span in product_title]

    item_url = soup.find_all(href=True)
    item_url = list(set([i['href'] for i in item_url if i['href'][-4:] == "html"]))
    
    #soup.find_all('a', {'class': 'thumbnail product-thumbnail'})[0]['href']
    #thumbnail product-thumbnail

    #images = soup.find_all('img', {'src' : 'img-fluid  product-thumbnail-first'})
    #3images = [span.get_text() for span in images]

    images = []
    for a in soup.find_all('a', {'class' : 'thumbnail product-thumbnail'}):
        if a.img:
            images.append(a.img['src'])
    
    price = soup.find_all('div', {'class': 'product-price-and-shipping'})
    price = [parse_price(span.get_text()) for span in price]

    product_weight = soup.find_all("div", {"class": "product-reference text-muted"})
    product_weight = [span.get_text() for span in product_weight]
    product_weight = [w for w in product_weight if w.split()[0] != "Артикул:"]
    product_weight = [parse_weight(w.split()[-1]) for w in product_weight]

    if len(price) != len(product_title):
        diff = len(product_title) - len(price)
        for i in range(diff):
            price.append("None")

    per_kg_price = []
    for idx, p in enumerate(price):
        if p != "None" and product_weight[idx] != "None":
            per_kg_price.append(p / product_weight[idx] * 1000)
        else:
            per_kg_price.append("None")

    return price,per_kg_price, product_title, product_weight, images, item_url

fozzy_parser()
#%%
def main_parse():
    ach_price, ach_kg_price, ach_title, ach_weight, ach_images, ach_url = auchan_parser()
    epi_price, epi_kg_price, epi_title, epi_weight, epi_images, epi_url = epicentric_parser()
    foz_price, foz_kg_price, foz_title, foz_weight, foz_images, foz_url = fozzy_parser()

    result = []
    for idx, f in enumerate(ach_price):
        result_dict = {"StoreName": "Auchan", "Name":ach_title[idx], "StoreURL":"none", "ImageURL":ach_images[idx], "Price":ach_price[idx]}
        result.append(result_dict)

    for idx, f in enumerate(epi_price):
        result_dict = {"StoreName": "Epicentric", "Name":epi_title[idx], "StoreURL":"none", "ImageURL":epi_images[idx], "Price":epi_price[idx]}
        result.append(result_dict)

    for idx, f in enumerate(ach_price):
        result_dict = {"StoreName": "Fozzy", "Name":foz_title[idx], "StoreURL":"none", "ImageURL":foz_images[idx], "Price":foz_price[idx]}
        result.append(result_dict)


    return json.dumps({"items":result}, ensure_ascii=False)

#main_parse()
#%%
'''for i in range(len(ach_price)):
    print("\n")
    try:
        print(f"Name: {ach_title[i]}, price: {ach_price[i]}, price: {ach_kg_price[i]}, weight: {ach_weight[i]}, image: {ach_images}")
    except Exception as e:
        print(e)
print("#####")
for i in range(len(epi_price)):
    print("\n")
    try:
        print(f"Name: {epi_title[i]}, price: {epi_price[i]}, price: {epi_kg_price[i]}, weight: {epi_weight[i]}, image: {epi_images}")
    except Exception as e:
        print(e)
print("#####")
for i in range(len(foz_weight)):
    print("\n")
    try:
        print(f"Name: {foz_title[i]}, price: {foz_price[i]}, price: {foz_kg_price[i]}, weight: {foz_weight[i]}, image: {foz_images}")
    except Exception as e:
        print(e)
'''
