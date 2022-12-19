import { useEffect, useState } from "react";
import { Modal } from "react-daisyui"
import { acceptInvitation, declineInvitation, getInivatations } from "../api/invitation";
import { Invitation, User } from "../utils/types";

type Props = {
    visible: boolean;
    toggleVisible: React.Dispatch<React.SetStateAction<boolean>>;
    user?: User;
}

export const InvitiationsModal = ({ user, visible, toggleVisible }: Props) => {
    const [invitations, setInvitations] = useState<Invitation[] | null>(null)

    useEffect(() => {
        if (visible) {
            getInivatations(user?.id).then(inv => setInvitations(inv))
        }
    }, [visible, user])

    const handleAccept = (invitationId: string, userId?: string ) => {
        acceptInvitation(invitationId, userId).then(() => toggleVisible(false))
    }

    if (!invitations && visible) {
        return (
            <div className="flex justify-center items-center">
                <div className="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full" role="status">
                </div>
            </div>)
    }

    return (
        <Modal open={visible} onClickBackdrop={() => toggleVisible(false)} className={'min-w-96 overflow-visible'}>
            <Modal.Header className="font-bold">
                Your invitations
            </Modal.Header>

            <Modal.Body>
                {invitations?.length === 0 ? "No invitations" : ''}
                {invitations?.map(inv => (
                    <div className="card w-96 bg-base-100 shadow-xl">
                        <div className="card-body flex flex-row">
                            <p>{`${inv.authorName} is inviting you to attend ${inv.title} on ${inv.startTime}`}</p>
                            <div className="my-auto card-actions justify-end">
                                <button onClick={() => handleAccept(inv.id, user?.id)} className="btn btn-square btn-sm">
                                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" className="w-6 h-6">
                                        <path strokeLinecap="round" strokeLinejoin="round" d="M4.5 12.75l6 6 9-13.5" />
                                    </svg>
                                </button>
                                <button onClick={() => declineInvitation(inv.id, user?.id).then(() => toggleVisible(false))} className="btn btn-square btn-sm">
                                    <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12" /></svg>
                                </button>
                            </div>
                        </div>

                    </div>
                ))}
            </Modal.Body>
        </Modal>
    )
}