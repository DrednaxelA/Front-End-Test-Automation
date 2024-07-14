async function delay(ms) {
    return new Promise(resolve => {
        setTimeout(() => {
            resolve();
        }, ms);
    })
}

async function askQuestion(question) { // a promise which holds the user's answer after prompting them a question
    return new Promise ((resolve) => {
        const answer = prompt(question);
        resolve(answer);
    })
}

async function startAdventure() {
    console.log("Welcome to the simple text adventure game!");

    let currentPath = 'start'
    while (true) {
        switch(currentPath){
            case 'start':
                console.log("You find yourself in a dark forest. You can go 'left' or 'right'.");
                const startChoice = await askQuestion("What do you do? (left/right): ");
                await delay(1000);
                if (startChoice.toLowerCase() === 'left') {
                    currentPath = 'left';
                }
                else if (startChoice.toLowerCase() === 'right') {
                    currentPath = 'right';
                }
                else {
                    console.log('Invalid choice. Please try again.');
                }
                break;
            case 'left':
                console.log("You encounter a wild animal! You can 'fight' or 'run'.");
                const leftChoice = await askQuestion("What do you do? (fight/run): ");
                await delay(1000);
                if (leftChoice.toLowerCase() === 'fight') {
                    console.log("You bravely fight the animal and win!");
                    currentPath = 'end';
                }
                else if (leftChoice.toLowerCase() === 'run') {
                    console.log("You run away safely.");
                    currentPath = 'start';
                }
                else {
                    console.log('Invalid choice. Please try again.');
                }
                break;
            case 'right':
                console.log("You find a treasure chest! You can 'open' it or 'leave' it.");
                const rightChoice = await askQuestion("What do you do? (open/leave): ");
                if (rightChoice.toLowerCase() === 'open') {
                    console.log("You open the chest and find a treasure! You win!");
                    currentPath = 'end';
                }
                else if (rightChoice.toLowerCase() === 'leave') {
                    console.log("You leave the chest and go back to the start.");
                    currentPath = 'start';
                }
                else {
                    console.log('Invalid choice. Please try again');
                }
                break;
            case 'end':
                const playAgain = askQuestion("Do you want to play again? (yes/no)");
                if (playAgain.toLowerCase() === 'yes') {
                    currentScene = "start";
                } else {
                    console.log("Thank you for playing!");
                    return;
                }
                break;
            default:
                console.log('Something went wrong - restarting the game.');
                currentPath = 'start';
                break;
        }
    }
}

window.startAdventure = startAdventure;





// Welcome message: 
// "Welcome to the simple text adventure game!"

// case "start": 
// "You find yourself in a dark forest. You can go 'left' or 'right'."
// question: "What do you do? (left/right): "

// case "left":
// message: "You encounter a wild animal! You can 'fight' or 'run'."
// question: "What do you do? (fight/run): "
// fight: "You bravely fight the animal and win!"
// run: "You run away safely."

// case "right": 
// message: "You find a treasure chest! You can 'open' it or 'leave' it."
// question: "What do you do? (open/leave): "
// open: "You open the chest and find a treasure! You win!"
// run: "You leave the chest and go back to the start."


// End message: "Do you want to play again? (yes/no): "
// yes: start game again
// no: "Thank you for playing!"