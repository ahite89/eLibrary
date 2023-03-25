import '../scss/BookList.scss';
import BookShow from './BookShow';

function BookList({ books, onDelete, onEdit, onCheck, userRole }) {

    const listOfBooks = books.map((book) => {
        return <BookShow
            key={book.id}
            book={book}
            onDelete={onDelete}
            onEdit={onEdit}
            onCheck={onCheck}
            userRole={userRole}
        />
    });

    return (
        <>
            <div className='book-list'>
                {listOfBooks}
            </div>
        </>
    );
}

export default BookList;