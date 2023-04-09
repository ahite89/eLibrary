import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7010';

const responseBody = (response) => response.data;

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody)
}

const bookFormData = (book, file, username = "") => {
    let bookData = new FormData();
    if (book.Id !== null) {
        bookData.append('Id', book.Id);
    }
    bookData.append('Title', book.Title);
    bookData.append('Author', book.Author);
    bookData.append('Description', book.Description);
    bookData.append('Year', book.Year);
    bookData.append('BookCoverFile', file);
    bookData.append('Username', username);

    return bookData;
}

const Library = {
    list: () => requests.get('/library'),
    create: (book, file, username) => {
        return requests.post('/library/create', bookFormData(book, file, username), {
            headers: {'content-type': 'multipart/form-data'}
        })
    },
    update: (book, file) => {
        return requests.post('/library/edit', bookFormData(book, file), {
            headers: { 'content-type': 'multipart/form-data' }
        })
    },
    checkout: (book) => requests.post('/library/checkout', book),
    checkin: (book) => requests.post('/library/checkin', book),
    delete: (book) => requests.post('/library/delete', book)
}

const Account = {
    current: (userData) => requests.post('/account/current', userData),
    login: (user) => requests.post('/account/login', user),
    register: (user) => requests.post('/account/register', user)
}

const agent = {
    Library,
    Account
}

export default agent;