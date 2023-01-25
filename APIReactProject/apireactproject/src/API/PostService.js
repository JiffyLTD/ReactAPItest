import axios from "axios";

export default class PostService{
    static async getAll(limit = 10, page = 1){
        const response = await axios
                .get(`https://localhost:7171/getAllPosts/limit=${limit}&page=${page}`);
        
        return response;
    }

    static async addNewPost(postTitle, postBody){
        const response =  await axios.post("https://localhost:7171/addNewPost",{
            title : postTitle,
            body : postBody
        });

        return response;
    }

    static async deletePost(postId){
        const response = await axios.delete(`https://localhost:7171/deletePost/id=${postId}`);

        return response;
    }
}