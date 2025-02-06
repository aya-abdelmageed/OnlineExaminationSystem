import requests
from bs4 import BeautifulSoup
import csv


page = requests.get("https://cbmceindia.com/blog/details/html-css-mcqs-with-answers/")

def main(page):
    src = page.content
    soup = BeautifulSoup(src, 'lxml')
    question_div = soup.find("div", {'class': 'page-blog-text'})
    questions = question_div.find_all("h3")
    
    # # for val in questions:
    # d = questions[0].find_all_next('p', limit=3)
    # question_text = d[0].text.strip()
    # choices = d[1].find_all('span')
    # answer = d[2].text.strip()
    # print(question_text)
    # for c in choices:
    #     print(c.text.strip())
    # print(answer)


    with open("questions_and_answers.txt", "w") as file:

        for val in questions:
            question_id = val.text
            section = val.find_all_next('p', limit=3)
            question_text = section[0].text.strip()
            choices = section[1].find_all('span')
            answer = section[2].text.strip()

            file.write(f"{question_id}: {question_text}\n")

            for choice in choices:
                file.write(f"Choice: {choice.get_text(strip=True)}\n")

            # Write the correct answer
            file.write(f"Answer: {answer}\n\n")



main(page)
