import React from 'react';

const PostItem = () => {
    return (
        <div className="post">
            <div className="postContent">
                <strong>1. JS </strong>
                <div>
                    JS - это язык программирования
                </div>
            </div>
            <div className="postButtons">
                <button>Удалить</button>
            </div>
        </div>  
    );
}

export default PostItem;