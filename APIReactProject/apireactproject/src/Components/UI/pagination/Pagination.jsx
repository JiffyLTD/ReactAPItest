import React from 'react';
import {getArrayPages} from '../../../utils/pages';

const Pagination = ({totalPages, page, changePage}) => {

  let pagesArray = getArrayPages(totalPages);

  return (
    <div className='page-buttons'>
        {
            pagesArray.map(p => 
                <span onClick={() => changePage(p)} key={p} className={page === p ?'page-button page-current ' : 'page-button'}>{p}</span>)
        }   
    </div>
  )
}

export default Pagination