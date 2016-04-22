function closeTabs(msg) {
    chrome.runtime.sendMessage({ greeting: "hello", msg: msg, value: 'value' }, function (response) {
        console.log(response.farewell);
    });
}
function sendMsg(greeting, msg) {
    chrome.runtime.sendMessage({ greeting: greeting, msg: msg, value: 'value' }, function (response) {
        console.log(response.farewell);
    });
}
function setMsg(greeting, msg, value) {
    chrome.runtime.sendMessage({ greeting: greeting, msg: msg, value: value }, function (response) {
        console.log(response.farewell);
    });
}