# import requests

# from bs4 import BeautifulSoup

# print("Enter the page number: ")
# p = int(input())
# page = requests.get(f"https://www.placementpreparation.io/mcq/sql/page/{p}/")

# def main(page):
#     src = page.content
#     # print(src)
#     soup = BeautifulSoup(src,"lxml")
#     # print(soup)
    
#     questions_div = soup.find('div', {'class':"question-and-answers-items"})

#     # print(questions_div)
#     questions = soup.find_all('div', {'class':'questionContent'})
#     details = soup.find_all('div', {'class':'questionDetails'})
#     for i in details:
#         print(i.text)
#         # # get the question
#         # print(i.find_next('div', {'class':'questionContentText'}).text.strip())
        
#         # ans = i.find_next('div', {'class':'questionFooter'}).find_next('div', {'class':'answerContainer'}).find_next('p', {'class':'answerContent'}).text.strip()
#         # print(ans)
#         # # get the options
#         # options = i.find_next('div', {'class':'optionContainer'}).find_all_next('p', {'class':'optionContent'})
#         # for j in range(4):
#         #     print(options[j].text.strip())

#         # # get the answer
        
#         print('#' * 50)

#     # print(questions[0].find_all('p', {'class':"questionNumber"})[0].text.strip())
#     # print('#' * 50)
#     # print(questions[0].find_next('div', {'class':'questionContentText'})[0].text.strip())




# # with open(f"questions_page_{p}.txt", "w", encoding="utf-8") as file:
# #         for question in questions_div:
# #             # Extract the question text
# #             question_text = question.find('div', class_='question-text').text.strip()
# #             # Write the question to the file
# #             file.write(f"Question: {question_text}\n")

# #             # Extract and write the options (if available)
# #             options = question.find_all('div', class_='option')
# #             for i, option in enumerate(options, start=1):
# #                 option_text = option.text.strip()
# #                 file.write(f"Option {i}: {option_text}\n")

# #             # Add a separator between questions
# #             file.write("\n" + "=" * 50 + "\n\n")
#     # options = soup.find_all('div', class_='options')
#     # for i in range(len(questions)):
#     #     print(questions[i].text)
#     #     print(options[i].text)
        
# main(page)


from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
from bs4 import BeautifulSoup
import time

# Configure Selenium
chrome_options = Options()
chrome_options.add_argument("--headless")  # Run in headless mode
service = Service('path/to/chromedriver')  # Replace with your chromedriver path
driver = webdriver.Chrome(service=service, options=chrome_options)

# Fetch the page
print("Enter the page number: ")
p = int(input())
url = f"https://www.placementpreparation.io/mcq/sql/page/{p}/"
driver.get(url)

# Wait for the page to load
time.sleep(5)  # Adjust the sleep time as needed

# Parse the page source with BeautifulSoup
soup = BeautifulSoup(driver.page_source, "lxml")

# Find all question details
details = soup.find_all('div', {'class': 'questionDetails'})

for i in details:
    # Get the question
    question_content = i.find_next('div', {'class': 'questionContentText'})
    if question_content:
        print(f"Question: {question_content.text.strip()}")
    else:
        print("Question content not found.")

    # Get the options
    option_container = i.find_next('div', {'class': 'optionContainer'})
    if option_container:
        options = option_container.find_all('p', {'class': 'optionContent'})
        for j, option in enumerate(options, start=1):
            print(f"Option {j}: {option.text.strip()}")
    else:
        print("Options not found.")

    # Click the "View Answer" button
    question_footer = i.find_next('div', {'class': 'questionFooter'})
    if question_footer:
        view_answer_button = question_footer.find('button', text='View Answer')
        if view_answer_button:
            # Use Selenium to click the button
            driver.execute_script("arguments[0].click();", view_answer_button)
            time.sleep(2)  # Wait for the answer to load

            # Parse the updated page source
            updated_soup = BeautifulSoup(driver.page_source, "lxml")
            updated_question_footer = updated_soup.find('div', {'class': 'questionFooter'})
            if updated_question_footer:
                answer_container = updated_question_footer.find_next('div', {'class': 'answerContainer'})
                if answer_container:
                    answer_content = answer_container.find('p', {'class': 'answerContent'})
                    if answer_content:
                        print(f"Answer: {answer_content.text.strip()}")
                    else:
                        print("Answer content not found.")
                else:
                    print("Answer container not found.")
            else:
                print("Updated question footer not found.")
        else:
            print("View Answer button not found.")
    else:
        print("Question footer not found.")

    print('#' * 50)

# Close the browser
driver.quit()