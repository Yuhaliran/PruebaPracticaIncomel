import {Col, Container, Row} from "reactstrap"

const App = () => {
    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de Contacto</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm">Nuevo Contacto</Button>
                        </CardBody>
                    </Card>
                </Col>
            </Row>
        </Container>
        )
}