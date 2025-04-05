import React, { useState } from 'react';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';

const PiBoard = ({ features }) => {
    const [items, setItems] = useState(features);

    const onDragEnd = (result) => {
        if (!result.destination) return;

        const reorderedItems = Array.from(items);
        const [removed] = reorderedItems.splice(result.source.index, 1);
        reorderedItems.splice(result.destination.index, 0, removed);

        setItems(reorderedItems);
    };

    return (
        <DragDropContext onDragEnd={onDragEnd}>
            <Droppable droppableId="piBoard">
                {(provided) => (
                    <div
                        ref={provided.innerRef}
                        {...provided.droppableProps}
                        style={{ padding: '20px', background: '#f0f0f0', borderRadius: '5px' }}
                    >
                        {items.map((feature, index) => (
                            <Draggable key={feature.id} draggableId={feature.id} index={index}>
                                {(provided) => (
                                    <div
                                        ref={provided.innerRef}
                                        {...provided.draggableProps}
                                        {...provided.dragHandleProps}
                                        style={{
                                            ...provided.draggableProps.style,
                                            padding: '10px',
                                            margin: '5px',
                                            background: '#fff',
                                            border: '1px solid #ccc',
                                            borderRadius: '3px',
                                        }}
                                    >
                                        {feature.name}
                                    </div>
                                )}
                            </Draggable>
                        ))}
                        {provided.placeholder}
                    </div>
                )}
            </Droppable>
        </DragDropContext>
    );
};

export default PiBoard;