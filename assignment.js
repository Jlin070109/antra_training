let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
};

let sum = 0;
for (let key in salaries) {
    sum += salaries[key];
}

console.log(sum); // Output: 390

////

function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof obj[key] === 'number') {
            obj[key] *= 2;
        }
    }
}

let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

multiplyNumeric(menu);

console.log(menu);
// Output:
// {
//     width: 400,
//     height: 600,
//     title: "My menu"
// }

/////////////////
function checkEmailId(str) {
    str = str.toLowerCase();
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.', atIndex);

    return atIndex > 0 && dotIndex > atIndex + 1;
}

console.log(checkEmailId("test@example.com")); // Output: true
console.log(checkEmailId("example.com@")); // Output: false
console.log(checkEmailId("test.email@example")); // Output: false
///////////////
function truncate(str, maxlength) {
    return str.length > maxlength ? str.slice(0, maxlength - 3) + "..." : str;
}

console.log(truncate("What I'd like to tell on this topic is:", 20)); // Output: "What I'd like to te..."
console.log(truncate("Hi everyone!", 20)); // Output: "Hi everyone!"
//////////////////

let styles = ["James", "Brennie"];
styles.push("Robert");
console.log(styles); // Output: ["James", "Brennie", "Robert"]

let middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
console.log(styles); // Output: ["James", "Calvin", "Robert"]

let firstValue = styles.shift();
console.log(firstValue); // Output: "James"
console.log(styles); // Output: ["Calvin", "Robert"]

styles.unshift("Rose", "Regal");
console.log(styles); // Output: ["Rose", "Regal", "Calvin", "Robert"]
