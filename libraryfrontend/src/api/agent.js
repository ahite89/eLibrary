import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7010';

const responseBody = (response) => response.data;

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody)
}

const Library = {
    list: () => requests.get('/library'),
    create: (book, file) => {
        let formData = new FormData();
        console.log(book);
        formData.append('Title', book.Title);
        formData.append('Author', book.Author);
        formData.append('Description', book.Description);
        formData.append('Year', book.Year);
        formData.append('BookCoverFile', file);
        return requests.post('/library/create', formData, {
            headers: {'content-type': 'multipart/form-data'}
        })
    },
    update: (book) => requests.post('/library/edit', book),
    checkout: (book) => requests.post('/library/checkout', book),
    checkin: (book) => requests.post('/library/checkin', book),
    delete: (book) => requests.post('/library/delete', book)
}

const Account = {
    current: () => requests.get('/account'),
    login: (user) => requests.post('/account/login', user),
    register: (user) => requests.post('/account/register', user)
}

const agent = {
    Library,
    Account
}

export default agent;