import React, { useEffect, useState } from 'react';
import MyButton from './../Components/UI/button/MyButton';
import MyModal from './../Components/ModalWindows/MyModal';
import PostFilter from './../Components/PostFilter';
import PostForm from './../Components/PostForm';
import Pagination from './../Components/UI/pagination/Pagination';
import { usePosts } from './../hooks/usePosts';
import { useFetching } from './../hooks/useFetching';
import PostList from './../Components/PostList';
import Loader from './../Components/UI/Loader/Loader';
import PostService from './../API/PostService';
import { getPageCount } from './../utils/pages';
import MyH1 from '../Components/UI/errorTitle/MyH1';


function Posts() {
    const [posts, setPosts] = useState([])
    const [filter, setFilter] = useState({sort: '', query: ''});
    const [modal, setModal] = useState(false);
    const [totalPages, setTotalPages] = useState(0);
    const [limit] = useState(10);
    const [page, setPage] = useState(1);
    const sortedAndSearchedPosts = usePosts(posts, filter.sort, filter.query);

    const [fetchPosts, isPostLoading, postError] = useFetching(async () => {
        const response = await PostService.getAll(limit, page);
        setPosts(response.data);
        const totalCount = response.headers['post-count'];
        setTotalPages(getPageCount(totalCount, limit));
    });

    useEffect(() => {
        fetchPosts();
    }, [page]);

    const createPost = (newPost) =>{
        setPosts([...posts, newPost])
        setModal(false)
    }

    const removePost = (post) =>{
        setPosts(posts.filter(p => p.id !== post.id))
    }

    const changePage = (page) => {
        setPage(page);
    }

    return (
        <div className="App">
            <MyButton style={{marginTop: '30px', marginLeft: '30px'}} onClick={() => setModal(true)}>Создать пост</MyButton>
            <MyButton style={{marginTop: '30px', marginLeft: '30px'}} onClick={() => fetchPosts()}>Обновить</MyButton>
            <hr style={{marginTop: '15px'}}/>
            <MyModal visible={modal} setVisible={setModal}>
                <PostForm create={createPost}/>
            </MyModal>
            <PostFilter filter={filter} setFilter={setFilter}/>
            <hr style={{margin: '15px 0'}}/>
            {postError && 
                <MyH1>Произошла ошибка: ${postError}</MyH1>
            }
            {
                isPostLoading
                ? <div style={{display: 'flex', justifyContent: 'center', marginTop: '50px'}}><h1 style={{marginTop: '30px', marginRight: '15px'}}>Загрузка</h1><Loader/></div>
                :<PostList remove={removePost} posts={sortedAndSearchedPosts} title="Список постов"/>
            }
            <Pagination page={page} changePage={changePage} totalPages={totalPages}/>
        </div>
        );
}

export default Posts;