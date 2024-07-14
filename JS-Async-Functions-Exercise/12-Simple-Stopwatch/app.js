let stopWatchSeconds = 0;
let stopWatchInterval;
let savedTimeInterval;
function startStopWatch() 
{
    stopWatchInterval = setInterval(() => {
        stopWatchSeconds++;
        console.log('Elapsed time: ' + stopWatchSeconds + ' s');
    }, 1000);

    savedTimeInterval = setInterval(async () => {
        await saveTime(stopWatchSeconds)
    }, 5000);

}

function stopStopWatch() 
{
    clearInterval(stopWatchInterval);
    clearInterval(savedTimeInterval)
    stopWatchSeconds = 0;
}

function saveTime(saveTime) {
    return new Promise((resolve, reject) => {
        console.log('Time saved: ' + saveTime + ' s');
        resolve()
    })
}