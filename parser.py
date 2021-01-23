#%%
import requests
from bs4 import BeautifulSoup
import time
import random
from tqdm import tqdm_notebook as tqdm
import gc
#%%
def auchan_parser():
    url = requests.get('https://auchan.zakaz.ua/uk/categories/buckwheat-auchan/')
    soup = BeautifulSoup(url.text, 'html.parser')
    #mydivs = soup.findAll("div", {"class": "jsx-3642073353 Price__value_caption"})
    prices = soup.find_all('span', {'class' : 'jsx-3642073353 Price__value_caption'})
    prices = [span.get_text() for span in prices]

    #images = soup.find_all('span', {'class' : 'jsx-725860710 product-tile__image-i'})
    #images = [span.get_text() for span in images]

    product_title = soup.find_all('span', {'class' : 'jsx-725860710 product-tile__title'})
    product_title = [span.get_text() for span in product_title]

    product_weight = soup.find_all('span', {'class' : 'jsx-725860710 product-tile__weight'})
    product_weight = [span.get_text() for span in product_weight]
# %%
def epicentric_parser():
    url = requests.get('https://epicentrk.ua/shop/krupy-i-makaronnye-izdeliya/fs/vid-krupa-grechnevaya/')
    soup = BeautifulSoup(url.text, 'html.parser')
    #mydivs = soup.findAll("div", {"class": "jsx-3642073353 Price__value_caption"})
    product_title = soup.find_all('b', {'class' : 'nc'})
    product_title = [span.get_text() for span in product_title]
    print(product_title)

    #images = soup.find_all('img', {'src' : 'card__photo'})
    #images = [span.get_text() for span in images]

    price = soup.find_all('span', {'class' : 'card__price-sum'})
    price = [span.get_text() for span in price]
    print(price)

    #product_weight = soup.find_all('span', {'class' : 'jsx-725860710 product-tile__weight'})
    #product_weight = [span.get_text() for span in product_weight]
# %%
def fozzy_parser():
    url = requests.get('https://fozzyshop.ua/300143-krupa-grechnevaya')
    soup = BeautifulSoup(url.text, 'html.parser')

    product_title =  soup.find_all('div', {'class' : 'h3 product-title'})
    product_title = [span.get_text() for span in product_title]

    price = soup.find_all('div', {'class': 'product-price-and-shipping'})
    price = [span.get_text() for span in price]

    #image = soup.find_all('div', {})

