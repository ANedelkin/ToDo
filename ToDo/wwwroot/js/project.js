document.addEventListener('DOMContentLoaded', e => {
    console.log('called');
    const tasks = document.querySelectorAll('.task');
    const columns = document.querySelectorAll('.column');

    let draggedTask = null;

    tasks.forEach(task => {
        task.addEventListener('dragstart', () => {
            draggedTask = task;
            task.classList.add('dragging');
        });

        task.addEventListener('dragend', () => {
            draggedTask = null;
            task.classList.remove('dragging');
        });
    });

    columns.forEach(column => {
        column.addEventListener('dragover', e => {
            e.preventDefault();
            column.classList.add('drag-over');
        });

        column.addEventListener('dragleave', () => {
            column.classList.remove('drag-over');
        });

        column.addEventListener('drop', () => {
            if (draggedTask) {
                const link = draggedTask.closest('.task-link');
                column.appendChild(link);
                column.classList.remove('drag-over');

                const header = draggedTask.querySelector('.task-header');
                header.className = 'task-header';
                header.classList.add(
                    column.classList.contains('pending') ? 'pending' :
                        column.classList.contains('inprogress') ? 'inprogress' : 'done'
                );
            }
        });
    });

    document.querySelectorAll('.task-link').forEach(link => {
        link.addEventListener('click', e => {
            if (draggedTask) {
                e.preventDefault();
            }
        });
    });
});