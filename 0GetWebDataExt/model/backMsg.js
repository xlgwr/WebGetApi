function closeTabs(msg) {
    chrome.runtime.sendMessage({ greeting: "hello", msg: msg }, function(response) {
        console.log(response.farewell);
    });
}
function sendMsg(greeting, msg) {
    chrome.runtime.sendMessage({ greeting: greeting, msg: msg }, function(response) {
        console.log(response.farewell);
    });
}