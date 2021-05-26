import React, { useState, useEffect } from 'react'
import axios from 'axios';

export default function LakewoodScoopScraper() {
    const [posts, setPosts] = useState([]);
    useEffect(() => {
        const getPosts = async () => {
            const { data } = await axios.get('/api/scraper/scrapeLakewoodscoop');
            setPosts(data);
        }
        getPosts();
    }, [])
    return (
        <>
            <div className="container">
            <div className="row">
                <h2>The Lakewood Scoop</h2>
            </div>
            <div className="row">
                <div className="col-md-8">
            {posts.map(p => {
                const {title,linkToArticle,imageUrl,text,commentAmount,date } = p;
                return (
                    < div className="card mb-4" >
                        <div className="card-body">
                            <h2 class="card-title">
                                <a href={linkToArticle} target="_blank">
                                    <h3>{title}</h3>
                                </a>
                            </h2>
                            <a href={linkToArticle} target="_blank">
                            <img className="align-center" src={imageUrl}/></a>
                            <p className="card-text">{text}</p>
                        </div>
                        <div className="card-footer text-muted">
                            {!!date &&
                                <div className="row">
                                    Posted on {date}
                                </div>}
                            <div className="row">
                                <h6> {commentAmount}</h6>
                            </div>
                        </div>
                    </div >)
            })
                    }
                </div>
            </div>
            </div>
        </>)               
}
          

