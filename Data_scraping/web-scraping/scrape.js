const puppeteer = require('puppeteer');
const fs = require('fs'); // Import the fs module

(async () => {
    try {
        // Launch the browser in headless mode
        const browser = await puppeteer.launch({ headless: true });
        const page = await browser.newPage();

        // Fetch the page
        const p = 4; // Replace with user input or dynamic value
        const url = `https://www.placementpreparation.io/mcq/sql/page/${p}/`;

        // Increase navigation timeout
        await page.goto(url, { waitUntil: 'networkidle2', timeout: 60000 }); // 60 seconds timeout

        console.log('Page loaded successfully.');

        // Wait for the page to load with a timeout
        try {
            await page.waitForSelector('.questionDetails', { timeout: 30000 }); // 30 seconds timeout
            console.log('Question details selector found.');
        } catch (error) {
            console.error('Error waiting for question details:', error);
            await browser.close();
            return;
        }

        // Extract question details
        const questions = await page.evaluate(() => {
            const details = [];
            const questionElements = document.querySelectorAll('.questionDetails');

            questionElements.forEach((question) => {
                const questionContent = question.querySelector('.questionContentText');
                const questionNumber = questionContent?.querySelector('.mobile-display-question')?.innerText.trim() || 'QN'; // Extract question number
                const questionText = questionContent?.querySelector('p')?.innerText.trim() || 'Question not found'; // Extract question text
                const options = question.querySelectorAll('.optionContainer .optionContent');
                const viewAnswerButton = question.querySelector('.questionFooter button');

                const questionData = {
                    questionNumber: questionNumber, // Add question number
                    question: questionText, // Add question text
                    options: [],
                    answer: null,
                };

                // Extract options
                options.forEach((option, index) => {
                    questionData.options.push(`Option ${index + 1}: ${option.innerText.trim()}`);
                });

                // Click the "View Answer" button if it exists
                if (viewAnswerButton && viewAnswerButton.innerText.trim() === 'View Answer') {
                    viewAnswerButton.click();
                }

                details.push(questionData);
            });

            return details;
        });

        console.log('Questions extracted successfully.');

        // Wait for answers to load
        await page.evaluate(() => {
            return new Promise((resolve) => setTimeout(resolve, 2000)); // Wait for 2 seconds
        });

        // Extract answers
        const updatedQuestions = await page.evaluate((questions) => {
            const questionElements = document.querySelectorAll('.questionDetails');
            const updatedDetails = [];

            questionElements.forEach((question, index) => {
                const answerContainer = question.querySelector('.answerContainer');
                const answerContent = answerContainer ? answerContainer.querySelector('.answerContent') : null;

                if (answerContent) {
                    questions[index].answer = answerContent.innerText.trim();
                } else {
                    questions[index].answer = 'Answer not found';
                }

                updatedDetails.push(questions[index]);
            });

            return updatedDetails;
        }, questions); // Pass the questions array as an argument

        console.log('Answers extracted successfully.');

        // Save the data to a text file
        const outputFilePath = 'scraped_questions.txt'; // Path to the output file
        let fileContent = ''; // Variable to store the file content

        updatedQuestions.forEach((question, index) => {
            fileContent += `${question.questionNumber}: ${question.question}\n`; // Include question number
            question.options.forEach((option) => {
                fileContent += `${option}\n`;
            });
            fileContent += `Answer: ${question.answer}\n`;
            fileContent += '#'.repeat(50) + '\n\n';
        });

        // Write the content to the file
        fs.appendFileSync(outputFilePath, fileContent, 'utf-8');
        console.log(`Data saved to ${outputFilePath}`);

        // Close the browser
        await browser.close();
    } catch (error) {
        console.error('Error during scraping:', error);
    }
})();