import React, { useEffect } from "react";
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import ShortLinkInfo from "./ShortLinkInfo";
import './Forms.css';

const ShortLink  = () => {
    const [loading, setLoading] = React.useState(false);
    const [shortLinks, setShortLinks] = React.useState([]);
    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('shortlink');
                const json = await response.json();
                setShortLinks(json);
            } catch (error) {
                console.log("error", error);
            }
        };

        fetchData();
    }, [])

     const handleRedirect = async (event) => {
        event.preventDefault();
        await fetch('shortlink/'+loading, {
            method: 'GET'
        });
    };
    const handleAddShortLink = async (event) => {
        event.preventDefault();
        await fetch('/shortlink?url='+loading,
            {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
                body: JSON.stringify({url: loading})
        });
        };
    return (
        <div>
            <table className="table table-striped" aria-labelledby="tableLabel" >
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Token</th>
                        <th>Url</th>
                        <th>Info</th>
                    </tr>
                </thead>
                <tbody>
                    {shortLinks.map(shortLink =>
                        <tr key={shortLink.id}>
                            <td>{shortLink.id}</td>
                            <td>{shortLink.token}</td>
                            <td>{shortLink.url}</td>
                            <td>
                                <NavLink tag={Link} to='/shortLinkInfo' state={{ id: shortLink.id }} >ShortLinkInfo</NavLink>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
            <p></p>
            <form onSubmit={handleAddShortLink} >
                <input type="text" className="field" placeholder="Input url" onChange={(event) => { setLoading(event.target.value) }} name="url" ></input>
                <button type="submit" className="btn"  >
                    Add ShortLink
                </button>
            </form>
            <p></p>
            <form onSubmit={handleRedirect} >
                <input type="text" className="field" placeholder="Input short token" onChange={(event) => { setLoading(event.target.value) }} name="url" ></input>
                <button type="submit" className="btn" >
                    Redirect
                </button>
            </form>
            </div>
            
    );
};

export default ShortLink;
