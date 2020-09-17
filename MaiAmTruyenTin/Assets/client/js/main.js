/* title */
let page = location.href.split("/").slice(-1)[0].split(".")[0];
let pageFolder = window.location.pathname.split("?")[0].split("/")[1];
switch (page) {
    case 'index':
    case '#':
        page='Trang Chủ';
        break;
    case 'lich-su':
        page='Lịch sử';
        break
    case 'quy-dinh':
        page='Quy định';
        break
    case 'tim-kiem':
        page='Tìm kiếm';
        break
    default:
        page = 'Mái ấm truyền tin';
};
if (pageFolder != location.href.split("?")[0].split("/").slice(-1)[0] && !!pageFolder) {
    document.title = pageFolder + ' - ' + page;
} else {
    document.title = page;
};

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