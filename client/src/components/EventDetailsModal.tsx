import { useEffect, useState } from "react";
import { Button, Input, Modal } from "react-daisyui"
import { getEventDetails, putEvent } from "../api/event";
import { EventDTO, User } from "../utils/types";

type Props = {
    visible: boolean;
    toggleVisible: React.Dispatch<React.SetStateAction<boolean>>;
    event: any;
    user?: User;
}

export const EventDetailsModal = ({ event, visible, toggleVisible, user }: Props) => {
    const [details, setDetails] = useState<any>(null)
    const [editMode, setEditMode] = useState(false)
    const [title, setTitle] = useState('')
    const [description, setDescription] = useState('')

    useEffect(() => {
        if (event && visible) {
            getEventDetails(event?.id).then(event => setDetails(event))
        }
    }, [event])

    const handlePut = () => {
        putEvent({...event, title, description}, user?.id).then(() => toggleVisible(false))
        // console.log({...event, title, description})
    }

    if (!details && visible) {
        return (
            <div className="flex justify-center items-center">
                <div className="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full" role="status">
                    <span className="visually-hidden">Loading...</span>
                </div>
            </div>)
    }

    return (
        <Modal open={visible} onClickBackdrop={() => toggleVisible(false)} className={'mx-32 min-w-fit overflow-visible'}>
            <Modal.Header className="font-bold">
                <div className="flex flex-row">
                    {`Event details - "${details?.title}"`}
                    {!editMode ? <Button className='ml-8' onClick={() => setEditMode(!editMode)}>Edit</Button>:
                    <Button className='ml-8' onClick={handlePut}>Submit</Button>}
                </div>
            </Modal.Header>

            <Modal.Body>
                {<div className="mx-32 overflow-hidden bg-white sm:rounded-lg">
                    <div className="">
                        <dl>
                            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Full title</dt>
                                {!editMode ? <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{details?.title || '-'}</dd> : 
                                <Input className={'w-32'} value={title} onChange={(e) => setTitle(e.target.value)} />}
                            </div>
                            <div className="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Author</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{details?.authorName || '-'}</dd>
                            </div>
                            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Description</dt>
                                {!editMode ? <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{details?.description || '-'}</dd>: 
                                <Input className={'w-32'} value={description} onChange={(e) => setDescription(e.target.value)} />}
                            </div>
                            <div className="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Start time</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{new Date(details?.startTime).toUTCString()}</dd>
                            </div>
                            <div className="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">End time</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{new Date(details?.endTime).toUTCString()}</dd>
                            </div>
                            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Atendees</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    {details?.atendees ? details?.atendees?.map((a: any) => `${a.name} (${a.email})\n`) : 'No other atendees'}
                                </dd>
                            </div>

                        </dl>
                    </div>
                </div>}
            </Modal.Body>
        </Modal>

    )
}