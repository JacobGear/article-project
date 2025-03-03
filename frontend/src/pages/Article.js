import { useParams } from "react-router-dom";
import { fetchArticles } from "../data/articles";
import { useEffect, useState } from "react";

function Article() {
  const { id } = useParams();
  const [article, setArticle] = useState(null);

  useEffect(() => {
    const getArticle = async () => {
      const articles = await fetchArticles(); // Ensure we await the data
      if (Array.isArray(articles)) {
        const foundArticle = articles.find((a) => a.id === Number(id));
        setArticle(foundArticle);
      } else {
        console.error("fetchArticles did not return an array:", articles);
      }
    };

    getArticle();
  }, [id]);

  if (!article) return <h1 className="text-danger">Article not found</h1>;

  return (
    <div className="container mt-4">
      <h1 className="display-4">{article.title}</h1>
      <p className="lead">{article.content}</p>
    </div>
  );
}

export default Article;
