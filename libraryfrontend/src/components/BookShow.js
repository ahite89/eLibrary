import '../scss/BookShow.scss';
import { useState } from 'react';
import { Button, Card, Typography, Dialog } from '@mui/material';
import BookEdit from './BookEdit';
import BookDelete from './BookDelete';

function BookShow({ book, onDelete, onEdit, onCheck, userData }) {

    const [openDeleteModal, setOpenDeleteModal] = useState(false);
    const [openEditModal, setOpenEditModal] = useState(false);

    const handleClickChangeCheckStatus = () => {
        onCheck(book);
    };

    const checkButtonDisabled = (book.checkedOut && userData.role === 'user')
        || (!book.checkedOut && userData.role === 'librarian');

    return (
        <Card className="book-show">
            <div className='book-contents-container'>
                <img className='book-cover' src={book.bookCoverUrl || '../images/bookCover.png'} />
                <div className='book-contents'>
                    <div className="book-title-actions-container">
                        <Typography variant="h4" className='book-title'>{book.title}</Typography>
                        {userData.role === "librarian" &&
                            <div className="book-actions">
                                <i className="bi bi-pencil-square toggle-edit-icon" onClick={() => setOpenEditModal(true)}></i>
                                <Dialog open={openEditModal} onClose={() => setOpenEditModal(false)}>
                                    <BookEdit
                                        book={book}
                                        onEdit={onEdit}
                                        onCloseModal={() => setOpenEditModal(false)}
                                    />
                                </Dialog>
                                <i className="bi bi-trash3 delete-icon" onClick={() => setOpenDeleteModal(true)}></i>
                                <Dialog className="delete-book-dialog" open={openDeleteModal} onClose={() => setOpenDeleteModal(false)}>
                                    <BookDelete
                                        book={book}
                                        onDelete={onDelete}
                                        onCloseModal={() => setOpenDeleteModal(false)}
                                    />
                                </Dialog>
                            </div>
                        }
                    </div>
                    <Typography variant="h5" className="book-author">by {book.author}</Typography>
                    <Typography variant="h5" className="book-year">{book.year}</Typography>
                    <Typography variant="h5" className='book-description'>{book.description}</Typography>
                    <div className="check-status-container">
                        <Typography variant="h5" className="availability-text"
                            style={{ color: book.checkedOut ? "#7c0000" : "green" }}>
                            {book.checkedOut ? "Not Available" : "Available"}
                        </Typography>
                        <Button
                            disabled={checkButtonDisabled}
                            variant="contained"
                            className='check-status-toggle-button'
                            onClick={handleClickChangeCheckStatus}>
                            Check {userData.role === 'user' ? 'out' : 'in'}
                        </Button>
                    </div>
                </div>
            </div>
        </Card>
    );
}

export default BookShow;