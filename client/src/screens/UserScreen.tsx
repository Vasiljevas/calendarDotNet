import React from "react"; 
import { useParams } from "react-router-dom";

export const UserScreen = () => {
    const { itemId } = useParams();

    return (
        <>
            UserScreen - {itemId}
        </>
    )
}