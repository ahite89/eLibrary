import '../scss/BookList.scss';
import BookShow from './BookShow';

function BookList({ books, onDelete, onEdit, onCheck, userData }) {

    const listOfBooks = books.sort((a, b) => a.title.localeCompare(b.title)).map((book) => {
        return <BookShow
            key={book.id}
            book={book}
            onDelete={onDelete}
            onEdit={onEdit}
            onCheck={onCheck}
            userData={userData}
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