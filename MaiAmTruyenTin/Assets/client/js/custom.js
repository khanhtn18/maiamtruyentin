
/* nav */
const appendNav = id => {
    let appendedTag = "appendedNav";
    if (document.getElementById(appendedTag) === null) {
    document.getElementById(id).innerHTML += `
    <ul class="navbar-nav bg-dcolor pl-5 m-0 hide-for-large" id=${appendedTag} 
        style="animation: appear 500ms">
        ${document.querySelector("#navbarSupportedContent ul").innerHTML}
    </ul>
    `;
    } else {document.getElementById(appendedTag).remove()}
    return null
};

/* footer */
window.onload = () => {
    document.getElementById('footer-nav').innerHTML = `
        ${document.querySelector("#navbarSupportedContent ul").innerHTML}`;
};

/* lich-su.html */
window.onload(
    document.querySelectorAll('#event-list li').forEach(event => {
        event.addEventListener('click', () => {
            document.getElementById('event-chosen').innerHTML = 
                `<h1 style="animation: appear 500ms;">
                    ${event.getElementsByTagName('a').item(0).innerHTML}
                </h1>`;
            document.getElementById('hiddenContentDiv').innerHTML = 
                `${event.getElementsByClassName('hiddenContent')[0].innerHTML}`;
            document.querySelector('#event-related ul').innerHTML = "";
            let eventArray = JSON.parse(event.dataset.relatedEvents);
            for (anEvent of eventArray) {
                document.querySelector('#event-related ul').innerHTML +=
                    `<li style="animation: appear 500ms;">
                        ${document.getElementById(anEvent).innerHTML}
                    </li>`;
            }
            document.querySelectorAll('#event-related li').forEach(eventRelated => {
                eventRelated.addEventListener('click', () => {
                    document.getElementById('event-chosen').innerHTML = 
                        `<h1 style="animation: appear 500ms;">
                            ${eventRelated.getElementsByTagName('a').item(0).innerHTML}
                        </h1>`;
                    document.getElementById('hiddenContentDiv').innerHTML = 
                        `${eventRelated.getElementsByClassName('hiddenContent')[0].innerHTML}`;
                })
            })
        })
    })
)
