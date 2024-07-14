async function startQuiz() {

    let finalScore = 0;

    for (let index = 0; index < questions.length; index++) {
        const {question, answers, correctAnswer} = questions[index]; //iterate over deconstructed questions objects, so we can retrieve the info
        const userInput = await askQuestion(question, answers); // we asked the user a question and took his input

        if (userInput == correctAnswer) {
            finalScore += 1;
            console.log('Correct!');
        }
        else {
            console.log('Incorrect!');
        }        
    }

    console.log(`Thanks for playing! Final score: ${finalScore}`);
}

function askQuestion(question, answers) 
{
    //asking questions will be asynchronous as we don't know how much time the user will need 
    return new Promise((resolve, reject) => {
        let message = question + '\n';
        answers.forEach((answer, index) => message += `${index}. ${answer}\n`);
        const userInput = prompt(message);
        resolve(parseInt(userInput)); //parse the string the user inputter to an integer
    })
};

const questions = [
    {
        question: 'What is 2 + 2?',
        answers: ['3', '4', '5'],
        correctAnswer: 1
    },
    {
        question: 'What is the capital of France',
        answers: ['Berlin', 'Madrid', 'Paris'],
        correctAnswer: 2
    },
    {
        question: 'What is the square root of 16?',
        answers: ['4', '5', '6'],
        correctAnswer: 0
    },
]