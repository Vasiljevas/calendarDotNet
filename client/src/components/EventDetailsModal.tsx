import { useEffect, useState } from "react";
import { Modal } from "react-daisyui"
import { getEventDetails } from "../api/event";

type Props = {
    visible: boolean;
    toggleVisible: React.Dispatch<React.SetStateAction<boolean>>;
    event: any;
}

export const EventDetailsModal = ({ event, visible, toggleVisible }: Props) => {
    const [details, setDetails] = useState<any>(null)

    useEffect(() => {
        if(event && visible) {
            getEventDetails(event?.id).then(event => setDetails(event))
        }
    }, [event])

    if(!details && visible) {
        return(
        <div className="flex justify-center items-center">
        <div className="spinner-border animate-spin inline-block w-8 h-8 border-4 rounded-full" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      </div>)
    }

    return (
        <Modal open={visible} onClickBackdrop={() => toggleVisible(false)} className={'mx-32 min-w-fit overflow-visible'}>
            <Modal.Header className="font-bold">
                {`Event details - "${details?.title}"`}
            </Modal.Header>

            <Modal.Body>
                <div className="mx-32 overflow-hidden bg-white sm:rounded-lg">
                    <div className="">
                        <dl>
                            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Full title</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{details?.title || '-'}</dd>
                            </div>
                            <div className="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Author</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{details?.authorName || '-'}</dd>
                            </div>
                            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                                <dt className="text-sm font-medium text-gray-500">Description</dt>
                                <dd className="mt-1 text-sm text-gray-900 sm:col-span-2 sm:mt-0">{details?.description || '-'}</dd>
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
                </div>
            </Modal.Body>
        </Modal>

    )
}