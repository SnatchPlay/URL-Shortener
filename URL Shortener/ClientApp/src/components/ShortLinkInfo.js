import React, { useEffect } from "react";
import { useLocation } from 'react-router-dom'

const ShortLinkInfo = () => {
    const [shortLink, setShortLink] = React.useState([]);
    let location = useLocation();
    useEffect(() => {
        const fetchData = async () => {

            try {
                const response = await fetch('shortlink/id='+location.state.id);
                const json = await response.json();
                setShortLink(json);
            } catch (error) {
                console.log("error", error);
            }
        };

        fetchData();
    }, [])

    console.log(location.state)
    return (
        <div>
            <table className="table table-striped" aria-labelledby="tableLabel" >
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Token</th>
                        <th>Url</th>
                        <th>CreatorUserId</th>
                        <th>Date of Creation</th>
                    </tr>
                </thead>
                <tbody>
                        <tr key={shortLink.id}>
                            <td>{shortLink.id}</td>
                            <td>{shortLink.token}</td>
                            <td>{shortLink.url}</td>
                            <td>{shortLink.creatorUserId}</td>
                            <td>{shortLink.rowInsertTime}</td>
                        </tr>
                    
                </tbody>
            </table>
        </div>

    );
};

export default ShortLinkInfo;
