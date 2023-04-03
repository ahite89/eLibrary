import { useState, useEffect } from 'react';
import { Typography, Container, Dialog, Button } from '@mui/material';

import BookList from './BookList';
import MyBookList from './MyBookList';
import BookCreate from './BookCreate';
import agent from '../api/agent';

function Library({ userData }) {

    const [books, setBooks] = useState([]);
    const [openCreateModal, setOpenCreateModal] = useState(false);

    // Get all books
    useEffect(() => {
        agent.Library.list().then(books => {
            setBooks(books);
        })
    }, []);

    // Create & Edit
    const createEditBook = async (book, file) => {

        // NEED TO ADD USERNAME

        if (book.Id == null) {
            agent.Library.create(book, file, 'ahite89').then((newBook) => {
                setBooks([...books, newBook]);
            })
        }
        else {
            agent.Library.update(book, file).then((updatedBook) => {
                setBooks([...books.filter(x => x.id !== updatedBook.id), updatedBook]);
            })
        }
    };

    // Check out & Check in
    const checkedOutBooks = books.filter((book) => {
        return book.checkedOut
    });

    const availableBooks = books.filter((book) => {
        return !book.checkedOut;
    });

    const changeCheckedStatusById = (book) => {

        if (book.checkedOut) {
            agent.Library.checkin(book).then((book) => {
                setBooks([...books.filter(x => x.id !== book.id), book]);
            })
        }
        else {
            agent.Library.checkout(book).then((book) => {
                setBooks([...books.filter(x => x.id !== book.id), book]);
            })
        }       
    };

    // Delete
    const deleteBookById = (book) => {

        agent.Library.delete(book).then((book) => {
            setBooks([...books.filter(x => x.id !== book.id)]);
        })
    };

    return (
        <Container>          
            <div className='available-books-list-container col-md-9'>
                <Typography variant="h4" className='book-list-text'>
                    {userData.role === 'librarian' ? 'Current Collection' : 'Browse our Collection'}
                </Typography>                    
                <hr />
                {books.length === 0 &&
                    <Typography variant="h6" className='book-count-text'>
                        There are no books in this library
                    </Typography>
                }
                {userData.role === 'librarian' &&
                    <div className="add-book-container">
                        <Button variant="outlined" onClick={() => setOpenCreateModal(true)}>
                            Add a new book
                        </Button>
                        <Dialog open={openCreateModal} onClose={() => setOpenCreateModal(false)}>
                            <BookCreate onCreate={createEditBook} onCloseModal={() => setOpenCreateModal(false)} />
                        </Dialog>
                    </div>
                }
                <BookList
                    books={userData.role === 'user' ? availableBooks : books}
                    onDelete={deleteBookById}
                    onEdit={createEditBook}
                    onCheck={changeCheckedStatusById}
                    userData={userData}
                />
            </div>
            {userData.role === 'user' &&
                <div className='my-book-list-container col-md-3'>
                    <Typography variant="h4" className='book-list-text'>My Books</Typography>
                    <hr />
                    <Typography variant="h6" className='book-count-text'>
                        You have {checkedOutBooks.length} {checkedOutBooks.length === 1 ? 'book' : 'books'} checked out
                    </Typography>
                    <MyBookList
                        books={checkedOutBooks}
                    />
                </div>
            }
        </Container>      
    );
}

export default Library;