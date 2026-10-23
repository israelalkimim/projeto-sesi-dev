/**
 * SESI INDÚSTRIA - CATÁLOGO DE CURSOS (CTED - SESI/SENAI)
 * Lógica Front-End integrada à API C#/.NET 8
 * Funcionalidades: Consulta, Pesquisa em tempo real, Filtros Combinados,
 * Detalhes do Curso, Estados de Loading, Vazio e Erro, Acessibilidade.
 */

document.addEventListener('DOMContentLoaded', () => {
    // Elementos DOM principais
    const searchInput = document.getElementById('searchInput');
    const selectCategoria = document.getElementById('selectCategoria');
    const selectModalidade = document.getElementById('selectModalidade');
    const selectStatus = document.getElementById('selectStatus');
    const btnLimpar = document.getElementById('btnLimpar');
    const cursosGrid = document.getElementById('cursosGrid');
    const feedbackArea = document.getElementById('feedbackArea');
    const contadorResultados = document.getElementById('contadorResultados');
    
    // Modal de Detalhes
    const modalOverlay = document.getElementById('modalCurso');
    const modalCloseBtn = document.getElementById('modalCloseBtn');
    const modalCloseFooter = document.getElementById('modalCloseFooter');
    const modalTitle = document.getElementById('modalTitle');
    const modalCategory = document.getElementById('modalCategory');
    const modalDescricao = document.getElementById('modalDescricao');
    const modalModalidade = document.getElementById('modalModalidade');
    const modalCarga = document.getElementById('modalCarga');
    const modalStatus = document.getElementById('modalStatus');
    const modalData = document.getElementById('modalData');
    const modalPublico = document.getElementById('modalPublico');
    const modulosList = document.getElementById('modulosList');

    // Menu Mobile
    const menuToggle = document.getElementById('menuToggle');
    const mainNav = document.getElementById('mainNav');

    if (menuToggle && mainNav) {
        menuToggle.addEventListener('click', () => {
            mainNav.classList.toggle('open');
            const isOpen = mainNav.classList.contains('open');
            menuToggle.setAttribute('aria-expanded', isOpen);
        });
    }

    // Variável para controle de debounce na digitação
    let searchDebounceTimeout = null;

    // Inicialização
    carregarFiltros();
    carregarCursos();

    // Eventos de Filtro e Busca
    searchInput.addEventListener('input', () => {
        clearTimeout(searchDebounceTimeout);
        searchDebounceTimeout = setTimeout(() => {
            carregarCursos();
        }, 300);
    });

    selectCategoria.addEventListener('change', () => carregarCursos());
    selectModalidade.addEventListener('change', () => carregarCursos());
    selectStatus.addEventListener('change', () => carregarCursos());

    btnLimpar.addEventListener('click', () => {
        searchInput.value = '';
        selectCategoria.value = 'todas';
        selectModalidade.value = 'todas';
        selectStatus.value = 'todos';
        carregarCursos();
    });

    /**
     * Carrega as opções disponíveis para os selects a partir da API C#
     */
    async function carregarFiltros() {
        try {
            const response = await fetch('/api/cursos/filtros');
            if (!response.ok) return;

            const data = await response.json();

            // Preenche Categorias
            data.categorias.forEach(cat => {
                const opt = document.createElement('option');
                opt.value = cat;
                opt.textContent = cat;
                selectCategoria.appendChild(opt);
            });

            // Preenche Modalidades
            data.modalidades.forEach(mod => {
                const opt = document.createElement('option');
                opt.value = mod;
                opt.textContent = mod;
                selectModalidade.appendChild(opt);
            });

            // Preenche Status
            data.status.forEach(st => {
                const opt = document.createElement('option');
                opt.value = st;
                opt.textContent = st;
                selectStatus.appendChild(opt);
            });
        } catch (error) {
            console.warn('Não foi possível carregar os filtros dinâmicos da API:', error);
        }
    }

    /**
     * Consulta os cursos na API C#/.NET aplicando busca e filtros combinados
     */
    async function carregarCursos() {
        exibirCarregamento();

        const params = new URLSearchParams();
        const search = searchInput.value.trim();
        const categoria = selectCategoria.value;
        const modalidade = selectModalidade.value;
        const status = selectStatus.value;

        if (search) params.append('search', search);
        if (categoria && categoria !== 'todas') params.append('categoria', categoria);
        if (modalidade && modalidade !== 'todas') params.append('modalidade', modalidade);
        if (status && status !== 'todos') params.append('status', status);

        const url = `/api/cursos?${params.toString()}`;

        try {
            const response = await fetch(url);

            if (!response.ok) {
                throw new Error(`Erro na API: ${response.status}`);
            }

            const data = await response.json();
            renderizarCursos(data.cursos, data.total);
        } catch (error) {
            console.error('Erro ao consultar cursos:', error);
            exibirErro('Não foi possível carregar os cursos no momento. Verifique a conexão com o servidor e tente novamente.');
        }
    }

    /**
     * Exibe o estado visual de Carregamento (Skeleton cards)
     */
    function exibirCarregamento() {
        feedbackArea.style.display = 'none';
        cursosGrid.style.display = 'grid';
        contadorResultados.textContent = 'Carregando cursos...';

        let skeletonsHtml = '';
        for (let i = 0; i < 6; i++) {
            skeletonsHtml += `
                <div class="skeleton-card" aria-hidden="true">
                    <div class="skeleton-thumb"></div>
                    <div class="skeleton-line title"></div>
                    <div class="skeleton-line"></div>
                    <div class="skeleton-line short"></div>
                </div>
            `;
        }
        cursosGrid.innerHTML = skeletonsHtml;
    }

    /**
     * Renderiza os cards de cursos ou exibe estado vazio quando total for zero
     */
    function renderizarCursos(cursos, total) {
        if (!cursos || cursos.length === 0) {
            cursosGrid.style.display = 'none';
            cursosGrid.innerHTML = '';
            contadorResultados.innerHTML = 'Nenhum curso encontrado (<strong class="contador-destaque">0</strong>)';
            exibirVazio();
            return;
        }

        feedbackArea.style.display = 'none';
        cursosGrid.style.display = 'grid';
        contadorResultados.innerHTML = `Exibindo <strong class="contador-destaque">${total}</strong> curso${total > 1 ? 's' : ''} encontrado${total > 1 ? 's' : ''}`;

        cursosGrid.innerHTML = cursos.map(curso => {
            const statusClass = obterClasseStatus(curso.status);
            const iconeSvg = curso.iconeCategoria || '/assets/icon-ciencias-natureza-20px.svg';

            return `
                <article class="curso-card" data-id="${curso.id}">
                    <div class="card-thumb-container">
                        <img src="${curso.imagem}" alt="Imagem ilustrativa do curso ${curso.nomeBreve}" class="card-thumb" loading="lazy" />
                        <div class="categoria-badge">
                            <img src="${iconeSvg}" alt="" aria-hidden="true" />
                            <span>${curso.categoria}</span>
                        </div>
                        <span class="status-badge ${statusClass}">${curso.status}</span>
                    </div>
                    <div class="card-content">
                        <h3 class="curso-titulo" title="${curso.nomeCompleto}">${curso.nomeCompleto}</h3>
                        <p class="curso-descricao">${curso.descricao}</p>
                        <div class="curso-meta">
                            <span class="meta-pill">⏱️ ${curso.cargaHoraria}h</span>
                            <span class="meta-pill">🎓 ${curso.modalidade}</span>
                            <span class="meta-pill">📚 ${curso.totalModulos} módulos</span>
                        </div>
                        <div class="card-actions">
                            <button type="button" class="btn-detalhes" data-id="${curso.id}" aria-label="Ver detalhes do curso ${curso.nomeBreve}">
                                Ver Detalhes do Curso →
                            </button>
                        </div>
                    </div>
                </article>
            `;
        }).join('');

        // Vincular clique aos botões de detalhes
        document.querySelectorAll('.btn-detalhes').forEach(btn => {
            btn.addEventListener('click', (e) => {
                const id = e.currentTarget.getAttribute('data-id');
                abrirDetalhesCurso(id);
            });
        });
    }

    /**
     * Retorna a classe CSS correspondente ao status do curso
     */
    function obterClasseStatus(status) {
        if (!status) return '';
        const s = status.toLowerCase();
        if (s.includes('aberta')) return 'status-abertas';
        if (s.includes('breve')) return 'status-breve';
        return 'status-encerrada';
    }

    /**
     * Exibe o estado visual amigável quando nenhum curso for encontrado
     */
    function exibirVazio() {
        feedbackArea.style.display = 'block';
        feedbackArea.innerHTML = `
            <div class="feedback-box">
                <svg class="feedback-icon" fill="none" stroke="currentColor" viewBox="0 0 24 24" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.172 16.172a4 4 0 015.656 0M9 10h.01M15 10h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                </svg>
                <h3 class="feedback-title">Nenhum curso encontrado</h3>
                <p class="feedback-text">Não encontramos cursos com os critérios e filtros selecionados. Tente buscar por outros termos ou limpe os filtros aplicados.</p>
                <button type="button" class="btn-primary" id="btnFeedbackLimpar">Limpar Todos os Filtros</button>
            </div>
        `;

        document.getElementById('btnFeedbackLimpar')?.addEventListener('click', () => {
            btnLimpar.click();
        });
    }

    /**
     * Exibe o estado visual de erro caso haja falha na requisição da API
     */
    function exibirErro(mensagem) {
        cursosGrid.style.display = 'none';
        feedbackArea.style.display = 'block';
        contadorResultados.textContent = 'Erro de comunicação';
        feedbackArea.innerHTML = `
            <div class="feedback-box">
                <svg class="feedback-icon" fill="none" stroke="#D32F2F" viewBox="0 0 24 24" aria-hidden="true">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"></path>
                </svg>
                <h3 class="feedback-title" style="color: #D32F2F;">Ops! Ocorreu um problema</h3>
                <p class="feedback-text">${mensagem}</p>
                <button type="button" class="btn-primary" id="btnTentarNovamente">Tentar Novamente</button>
            </div>
        `;

        document.getElementById('btnTentarNovamente')?.addEventListener('click', () => {
            carregarCursos();
        });
    }

    /**
     * Consulta os detalhes de um curso específico na API e abre o Modal acessível
     */
    async function abrirDetalhesCurso(id) {
        try {
            const response = await fetch(`/api/cursos/${id}`);
            if (!response.ok) throw new Error('Falha ao buscar detalhes do curso');

            const curso = await response.json();

            modalTitle.textContent = curso.nomeCompleto;
            modalCategory.textContent = curso.categoria;
            modalDescricao.textContent = curso.descricao;
            modalModalidade.textContent = curso.modalidade;
            modalCarga.textContent = `${curso.cargaHoraria} horas`;
            modalStatus.textContent = curso.status;
            modalPublico.textContent = curso.publicoAlvo || 'Público geral interessado na indústria.';
            
            if (curso.dataDisponibilizacao) {
                const dataObj = new Date(curso.dataDisponibilizacao);
                modalData.textContent = dataObj.toLocaleDateString('pt-BR');
            } else {
                modalData.textContent = 'Imediato';
            }

            // Renderizar Módulos e Aulas
            if (curso.modulos && curso.modulos.length > 0) {
                modulosList.innerHTML = curso.modulos.map(m => `
                    <div class="modulo-item">
                        <div class="modulo-header">
                            <img src="/assets/add_2.svg" alt="" style="width: 14px; height: 14px; display: inline-block; vertical-align: middle; margin-right: 8px;" aria-hidden="true">
                            <span>${m.titulo}</span>
                        </div>
                        ${m.descricao ? `<div class="modulo-desc">${m.descricao}</div>` : ''}
                        ${m.aulas && m.aulas.length > 0 ? `
                            <ul class="aulas-list">
                                ${m.aulas.map(a => `
                                    <li class="aula-item">
                                        <span>• ${a.titulo}</span>
                                        <span class="duracao">⏱️ ${a.duracao}</span>
                                    </li>
                                `).join('')}
                            </ul>
                        ` : ''}
                    </div>
                `).join('');
            } else {
                modulosList.innerHTML = '<p style="color: #777; font-size: 0.9rem;">Grade curricular em atualização pedagógica.</p>';
            }

            abrirModal();
        } catch (error) {
            console.error(error);
            alert('Não foi possível carregar os detalhes do curso.');
        }
    }

    function abrirModal() {
        modalOverlay.classList.add('open');
        modalOverlay.setAttribute('aria-hidden', 'false');
        document.body.style.overflow = 'hidden';
        modalCloseBtn.focus();
    }

    function fecharModal() {
        modalOverlay.classList.remove('open');
        modalOverlay.setAttribute('aria-hidden', 'true');
        document.body.style.overflow = '';
    }

    modalCloseBtn.addEventListener('click', fecharModal);
    modalCloseFooter.addEventListener('click', fecharModal);
    modalOverlay.addEventListener('click', (e) => {
        if (e.target === modalOverlay) fecharModal();
    });

    // Tecla ESC para fechar modal (Acessibilidade WCAG)
    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && modalOverlay.classList.contains('open')) {
            fecharModal();
        }
    });
});
