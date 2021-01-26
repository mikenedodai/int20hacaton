FROM python:3

ADD parser.py /
ADD requirements.txt /

RUN pip install requirements

CMD [ "python", "./parser.py" ]