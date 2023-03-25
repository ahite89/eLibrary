import { useState, useEffect } from 'react';
import { Typography, Container, Dialog, Button } from '@mui/material';

import BookList from './BookList';
import MyBookList from './MyBookList';
import BookCreate from './BookCreate';
import agent from '../api/agent';

function Library({ userRole }) {

    const [books, setBooks] = useState([]);
    const [openCreateModal, setOpenCreateModal] = useState(false);

    // Get all books
    useEffect(() => {
        agent.Library.list().then(books => {
            setBooks(books);
        })
    }, []);

    // Create
    const createBook = async (book, file) => {

        agent.Library.create(book, file).then((newBook) => {
            setBooks([...books, newBook]);
        })
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

    // Edit
    const editBookById = (id, newTitle, newAuthor, newDescription, newYear) => {

        const bookData = {
            Id: id,
            Title: newTitle,
            Author: newAuthor,
            Description: newDescription,
            Year: newYear
        };

        agent.Library.update(bookData).then((book) => {
            setBooks([...books.filter(x => x.id !== book.id), book]);
        })
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
                <Typography variant="h4" className='book-list-text'>Browse our Collection</Typography>
                {userRole === 'librarian' &&
                    <div className="add-book-container">
                        <Button variant="contained" onClick={() => setOpenCreateModal(true)}>
                            Add a new book
                        </Button>
                        <Dialog open={openCreateModal} onClose={() => setOpenCreateModal(false)}>
                            <BookCreate onCreate={createBook} onCloseModal={() => setOpenCreateModal(false)} />
                        </Dialog>
                    </div>
                }
                <hr />
                {books.length === 0 &&
                    <Typography variant="h6" className='book-count-text'>
                        There are no books in this library
                    </Typography>
                }
                <BookList
                    books={userRole === 'user' ? availableBooks : books}
                    onDelete={deleteBookById}
                    onEdit={editBookById}
                    onCheck={changeCheckedStatusById}
                    userRole={userRole}
                />
            </div>
            {userRole === 'user' &&
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